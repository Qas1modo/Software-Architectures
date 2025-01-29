using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Contracts.Models.PremiumServiceModels;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.PremiumService.Commands.DeletePremiumService;

public record DeletePremiumServiceCommand(DeletePremiumServiceModel DeletePremiumServiceModel) : ICommand<Result>;
