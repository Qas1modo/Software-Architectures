using AccessSystem.Contracts.Models.AccessCard;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.AccessCard.Queries.GetCard;

public sealed record GetCardQuery(GetAccessCardModel GetAccessCardModel) : IQuery<Maybe<AccessCardResponseModel>>;