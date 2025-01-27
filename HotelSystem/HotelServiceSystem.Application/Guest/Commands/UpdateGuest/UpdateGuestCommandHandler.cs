using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Application.Guest.Commands.UpdateGuest;

public class UpdateGuestCommandHandler(IGuestRepository guestRepository, IUnitOfWork unitOfWork) 
    : ICommandHandler<UpdateGuestCommand, Result>
{
    private readonly IGuestRepository guestRepository = guestRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
    {
        var guest = await guestRepository.GetByIdAsync(request.UpdateGuestModel.GuestId);
        if (guest.HasNoValue)
        {
            return Result.Failure(DomainErrors.PremiumServiceErrors.NotFound);
        }
        Result<FirstName> firstName = FirstName.Create(request.UpdateGuestModel.GuestFirstName);
        Result<LastName> lastName = LastName.Create(request.UpdateGuestModel.GuestLastName);
        Result<RoomNumber> roomNumber = RoomNumber.Create(request.UpdateGuestModel.GuestRoom);
        Result<Email> email = Email.Create(request.UpdateGuestModel.Email);
        Result firstFailureOrSuccess = Result.FirstFailureOrSuccess(firstName, lastName, roomNumber, email);
        if (firstFailureOrSuccess.IsFailure)
        {
            return Result.Failure(firstFailureOrSuccess.Error);
        }
        var updatedEntity = guest.Value.Update(request.UpdateGuestModel.GlobalGuestId, firstName.Value, lastName.Value,
            roomNumber.Value, email.Value, request.UpdateGuestModel.Active);
        guestRepository.Update(updatedEntity);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}