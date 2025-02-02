using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Application.Invoice.Commands;

public record DeleteInvoiceCommand(Guid Id) : ICommand<Result>;
