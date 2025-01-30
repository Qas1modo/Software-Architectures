using HotelServiceSystem.Application.Core.Abstractions.Data;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Domain.Repositories;

namespace HotelServiceSystem.Application.PremiumOrder.Commands.CreatePremiumOrder;

public class CreateRoomOrderCommandHandler(IPremiumServiceOrderRepository premiumServiceOrderRepository,
    IPremiumServiceRepository premiumServiceRepository,
    IGuestRepository guestRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreatePremiumOrderCommand, Result>
{
    private readonly IPremiumServiceOrderRepository premiumServiceOrderRepository = premiumServiceOrderRepository;
    private readonly IPremiumServiceRepository premiumServiceRepository = premiumServiceRepository;
    private readonly IGuestRepository guestRepository = guestRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreatePremiumOrderCommand request, CancellationToken cancellationToken)
    {
        var premiumService = await premiumServiceRepository.GetByIdAsync(request.CreatePremiumOrderModel.PremiumServiceId);
        var guest = await guestRepository.GetByIdAsync(request.CreatePremiumOrderModel.GuestId);
        if (guest.HasNoValue) {
            return Result.Failure(DomainErrors.PremiumServiceOrderErrors.InvalidGuestId);
        }
        if (premiumService.HasNoValue)
        {
            return Result.Failure(DomainErrors.PremiumServiceOrderErrors.InvalidOrderedPremiumServiceId);
        }
        premiumServiceOrderRepository.Insert(PremiumServiceOrderEntity.Create(guest, premiumService.Value));
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
