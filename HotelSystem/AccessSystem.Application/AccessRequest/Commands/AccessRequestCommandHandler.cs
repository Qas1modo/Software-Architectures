using AccessSystem.Contracts.Models.AccessRequest;
using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Events.AccessRequest;
using AccessSystem.Domain.Repositories;
using MediatR;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessRequest.Commands;

public class AccessRequestCommandHandler(
    IAccessCardRepository accessCardRepository,
    IAccessClaimRepository accessClaimRepository,
    IAccessLogEntryRepository accessLogEntryRepository,
    IUnitOfWork unitOfWork,
    IMediator mediator
    )
    : ICommandHandler<AccessRequestCommand, Result>
{
    // refactor
    public async Task<Result> Handle(AccessRequestCommand request, CancellationToken cancellationToken)
    {
        var accessCard = await accessCardRepository.GetByIdAsync(request.RequestAccessModel.AccessCardId);
        
        if (accessCard.HasNoValue)
        {
            return Result.Failure(DomainErrors.AccessCardErrors.NotFound);
        }

        var accessClaim = await accessClaimRepository.GetByIdAsync(request.RequestAccessModel.ClaimId);
        if (accessClaim.HasNoValue)
        {
            return Result.Failure(DomainErrors.AccessCardErrors.NotFound);
        }
        var accessCardPermissionsIdsFromRoles = accessCard.Value.Roles
            .SelectMany(role => role.Permissions.Select(permission => permission.Id).ToHashSet())
            .ToList();

        var accessClaimValue = accessClaim.Value;
        var accessClaimPermissionsIds = accessClaimValue.AllowedPermissions.Select(permission => permission.Id).ToList();
        
        if (accessCardPermissionsIdsFromRoles.Intersect(accessClaimPermissionsIds).Any())
        {
            var accessLogEntry = AccessLogEntry.Create(accessCard.Value.Id, accessClaimValue.Id, DateTime.UtcNow, true);
            accessLogEntryRepository.Insert(accessLogEntry);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            var responseModel = new RequestAccessResponseModel
            {
                AccessCardId = accessCard.Value.Id,
                ClaimId = accessClaimValue.Id,
                IsAccessAllowed = true
            };
            
            await mediator.Publish(new AccessRequestApprovedDomainEvent(responseModel), cancellationToken);
            
            return Result.Success();
        }

        var cardPermissionsIds = accessCard.Value.Permissions.Select(permission => permission.Id).ToList();

        if (cardPermissionsIds.Intersect(accessClaimPermissionsIds).Any())
        {
            var accessLogEntry = AccessLogEntry.Create(accessCard.Value.Id, accessClaimValue.Id, DateTime.UtcNow, true);
            accessLogEntryRepository.Insert(accessLogEntry);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            var responseModel = new RequestAccessResponseModel
            {
                AccessCardId = accessCard.Value.Id,
                ClaimId = accessClaimValue.Id,
                IsAccessAllowed = true
            };
            
            await mediator.Publish(new AccessRequestApprovedDomainEvent(responseModel), cancellationToken);
            
            return Result.Success();
        }

        var accessLogEntryDenied = AccessLogEntry.Create(accessCard.Value.Id, accessClaimValue.Id, DateTime.UtcNow, false);
        accessLogEntryRepository.Insert(accessLogEntryDenied);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        var responseModelFailure = new RequestAccessResponseModel
        {
            AccessCardId = accessCard.Value.Id,
            ClaimId = accessClaimValue.Id,
            IsAccessAllowed = false
        };
            
        await mediator.Publish(new AccessRequestDeniedDomainEvent(responseModelFailure), cancellationToken);
        
        return Result.Failure(DomainErrors.AccessClaimErrors.AccessForbidden);

    }
}