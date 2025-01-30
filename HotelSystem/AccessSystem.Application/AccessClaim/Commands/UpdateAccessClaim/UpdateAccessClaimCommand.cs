using AccessSystem.Contracts.Models.AccessClaim;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessClaim.Commands.UpdateAccessClaim;

public record UpdateAccessClaimCommand(UpdateAccessClaimModel UpdateAccessClaimModel) : ICommand<Result>;