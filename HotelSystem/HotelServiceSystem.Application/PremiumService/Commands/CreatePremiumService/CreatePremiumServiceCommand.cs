using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using HotelServiceSystem.Contracts.Models.PremiumServiceModels;

namespace HotelServiceSystem.Application.PremiumService.Commands.CreatePremiumService
{
    public record CreatePremiumServiceCommand(CreatePremiumServiceModel CreatePremiumServiceModel) : ICommand<Result>;
}
