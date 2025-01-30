using AccessSystem.Contracts.Models.AccessClaim;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessClaim.Commands.CreateAccessClaim;

public record CreateAccessClaimCommand(CreateAccessClaimModel CreateAccessClaimModel) : ICommand<Result>;