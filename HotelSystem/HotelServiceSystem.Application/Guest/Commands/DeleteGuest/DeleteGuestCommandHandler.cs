using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.Guest.Commands.DeleteGuest;

public class DeleteGuestCommandHandler(IGuestRepository guestRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteGuestCommand, Result>
{
    private readonly IGuestRepository guestRepository = guestRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteGuestCommand request, CancellationToken cancellationToken)
    {
        var guest = await guestRepository.GetByIdAsync(request.GuestId);
        if (guest.HasNoValue)
        {
            return Result.Failure(DomainErrors.GuestErrors.NotFound);
        }
        guestRepository.Remove(guest.Value);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}