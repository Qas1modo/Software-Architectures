using AccessSystem.Contracts.Models.AccessCard;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessCard.Commands.CreateAccessCard;

public record CreateAccessCardCommand(CreateAccessCardModel CreateAccessCardModel) : ICommand<Result>;