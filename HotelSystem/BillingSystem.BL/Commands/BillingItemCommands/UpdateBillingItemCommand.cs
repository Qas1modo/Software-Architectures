using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.BL.Commands.BillingItemCommands;

public record UpdateBillingItemCommand(BillinItemUpdateModel BillinItemUpdateModel) : IRequest<BillingItemDetailModel>;
