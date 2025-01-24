using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models;
using HotelServiceSystem.Contracts.Models.PremiumService;

namespace HotelServiceSystem.Application.PremiumService.Commands.RemovePremiumService;

public record RemovePremiumServiceCommand(RemovePremiumServiceModel RemovePremiumServiceModel) : ICommand<GenericResponseModel>;
