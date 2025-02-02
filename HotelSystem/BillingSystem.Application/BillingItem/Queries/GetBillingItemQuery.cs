using BillingSystem.Shared.Models.BillingItem;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace BillingSystem.Application.BillingItem.Queries;

public record GetBillingItemQuery(Guid BillingItemId) : IQuery<Maybe<BillingItemDetailModel>>;
