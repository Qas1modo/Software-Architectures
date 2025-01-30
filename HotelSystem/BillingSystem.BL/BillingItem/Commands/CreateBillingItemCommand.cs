using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.Application.BillingItem.Commands;

public record CreateBillingItemCommand(BillingItemCreateModel BillingItemCreateModel) : IRequest<BillingItemDetailModel>;
