using AccessSystem.Contracts.Models.AccessCard;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.AccessCard.Queries;

public sealed record AccessCardGetCardQuery(GetAccessCardModel GetAccessCardModel) : IQuery<Maybe<AccessCardResponseModel>>;