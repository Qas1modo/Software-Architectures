using HotelServiceSystem.Contracts.Models.PremiumService;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Application.Core.Abstractions.Messaging;

namespace HotelServiceSystem.Application.PremiumService.Commands.UpdatePremiumService;

public record UpdatePremiumServiceCommand(UpdatePremiumServiceModel UpdatePremiumServiceModel) : ICommand<GenericResponseModel>;
