using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.Application.BillingItem.Commands;

public record UpdateBillingItemCommand(BillinItemUpdateModel BillinItemUpdateModel) : IRequest<BillingItemDetailModel>;
