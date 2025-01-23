using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.BL.Commands.BillingItemCommands;

public record CreateBillingItemCommand(BillingItemCreateModel BillingItemCreateModel) : IRequest<BillingItemDetailModel>;
