using AccessSystem.Contracts.Models.AccessClaim;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.AccessClaim.Queries.GetAccessClaim;

public record GetAccessClaimQuery(GetAccessClaimModel GetAccessClaimModel) : IQuery<Maybe<List<AccessClaimResponseModel>>>;