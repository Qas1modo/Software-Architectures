using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.Guest.Commands.DeactivateGuest;

public class DeactivateGuestCommandHandler(IGuestRepository guestRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<DeactivateGuestCommand, Result>
{
    private readonly IGuestRepository guestRepository = guestRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeactivateGuestCommand request, CancellationToken cancellationToken)
    {
        var result = await guestRepository.DeactivateGuest(request.GlobalGuestId);
        if (result.IsSuccess) await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}