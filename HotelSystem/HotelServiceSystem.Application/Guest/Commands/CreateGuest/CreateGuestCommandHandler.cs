using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Application.Guest.Commands.CreateGuest;

public class CreateGuestCommandHandler(IGuestRepository guestRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateGuestCommand, Result>
{
    private readonly IGuestRepository guestRepository = guestRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
    {
        Result<FirstName> guestFirstName = FirstName.Create(request.CreateGuestModel.GuestFirstName);
        Result<LastName> guestLastName = LastName.Create(request.CreateGuestModel.GuestLastName);
        Result<RoomNumber> guestRoomNumber = RoomNumber.Create(request.CreateGuestModel.GuestRoom);
        Result<Email> email = Email.Create(request.CreateGuestModel.Email);
        Result firstFailureOrSuccess = Result.FirstFailureOrSuccess(guestFirstName, guestLastName, guestRoomNumber, email);
        if (firstFailureOrSuccess.IsFailure)
        {
            return Result.Failure(firstFailureOrSuccess.Error);
        }
        var guestEntity = GuestEntity.Create(request.CreateGuestModel.GlobalGuestId, guestFirstName.Value, guestLastName.Value,
            guestRoomNumber.Value, email.Value);
        guestRepository.Insert(guestEntity);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
