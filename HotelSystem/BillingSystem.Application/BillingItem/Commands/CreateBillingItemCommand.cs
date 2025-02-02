using BillingSystem.Shared.Models.BillingItem;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Application.BillingItem.Commands;

public record CreateBillingItemCommand(BillingItemCreateModel BillingItemCreateModel) : ICommand<Result>;
