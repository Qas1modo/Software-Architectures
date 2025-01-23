using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.BL.Queries.BillingItemQueries;

public record GetBillingItemsByCustomerQuery(int CustomerId, int Page = -1, int PageSize = -1) : IRequest<List<BillingItemListModel>>;
