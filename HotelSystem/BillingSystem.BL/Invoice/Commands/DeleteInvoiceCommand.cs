using MediatR;

namespace BillingSystem.Application.Invoice.Commands;

public record DeleteInvoiceCommand(int Id) : IRequest<bool>;
