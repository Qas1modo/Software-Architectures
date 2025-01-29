using AccessSystem.Contracts.Models.AccessClaim;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessClaim.Commands.DeleteAccessClaim;

public record DeleteAccessClaimCommand(DeleteAccessClaimModel DeleteAccessClaimModel) : ICommand<Result>;