using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.PremiumServiceModels;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.PremiumService.Commands.UpdatePremiumService;

public record UpdatePremiumServiceCommand(UpdatePremiumServiceModel UpdatePremiumServiceModel) : ICommand<Result>;
