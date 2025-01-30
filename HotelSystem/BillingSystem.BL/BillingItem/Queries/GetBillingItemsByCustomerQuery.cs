using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.Application.BillingItem.Queries;

public record GetBillingItemsByCustomerQuery(Guid CustomerId, int Page = -1, int PageSize = -1) : IRequest<List<BillingItemListModel>>;
