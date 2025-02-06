using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessCard.Commands.UpdateAccessCardFromOrder;

public class UpdateAccessCardFromOrderCommandHandler(
    IAccessCardRepository accessCardRepository,
    IRoleRepository roleRepository,
    IAccessCardRoleRepository accessCardRoleRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateAccessCardFromOrderCommand, Result>
{
    public async Task<Result> Handle(UpdateAccessCardFromOrderCommand request, CancellationToken cancellationToken)
    {
        var accessCard = await accessCardRepository.GetByHolderId(request.UpdateAccessCardFromOrderModel.HolderId);
        
        if (accessCard.HasNoValue)
        {
            return Result.Failure(DomainErrors.AccessCardErrors.NotFound);
        }
        
        if (accessCard.Value.RoleNames.Contains(request.UpdateAccessCardFromOrderModel.RoleNameToAdd))
        {
            return Result.Failure(DomainErrors.AccessCardErrors.RoleAlreadyAssigned);
        }

        var roleToAdd = await roleRepository.GetRolesByNames([request.UpdateAccessCardFromOrderModel.RoleNameToAdd],
            cancellationToken);

        if (roleToAdd.HasNoValue || roleToAdd.Value.Count == 0)
        {
            return Result.Failure(DomainErrors.RoleErrors.NotFound);
        }
        

        await accessCardRoleRepository.AddRolesToCardByName(accessCard.Value.Id, [request.UpdateAccessCardFromOrderModel.RoleNameToAdd],
            cancellationToken);
        

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}