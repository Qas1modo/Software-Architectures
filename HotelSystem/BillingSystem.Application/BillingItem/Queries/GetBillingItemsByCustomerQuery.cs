using BillingSystem.Shared.Models.BillingItem;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace BillingSystem.Application.BillingItem.Queries;

public record GetBillingItemsByCustomerQuery(Guid CustomerId, int Page = -1, int PageSize = -1) : IQuery<Maybe<List<BillingItemListModel>>>;

