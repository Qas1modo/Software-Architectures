using BillingSystem.Shared.Models.Invoice;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Application.Invoice.Commands;

public record CreateInvoiceCommand(InvoiceCreateModel InvoiceCreateModel) : ICommand<Result>;
