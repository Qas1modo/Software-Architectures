using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.Application.BillingItem.Queries;

public record GetBillingItemQuery(int BillingItemId) : IRequest<BillingItemDetailModel>;
