using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.BL.Queries.BillingItemQueries;

public record GetBillingItemQuery(int BillingItemId) : IRequest<BillingItemDetailModel>;
