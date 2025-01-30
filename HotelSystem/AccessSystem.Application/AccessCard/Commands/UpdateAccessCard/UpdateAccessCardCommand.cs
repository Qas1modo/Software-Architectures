using AccessSystem.Contracts.Models.AccessCard;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessCard.Commands.UpdateAccessCard;

public record UpdateAccessCardCommand(UpdateAccessCardModel UpdateAccessCardModel) : ICommand<Result>;