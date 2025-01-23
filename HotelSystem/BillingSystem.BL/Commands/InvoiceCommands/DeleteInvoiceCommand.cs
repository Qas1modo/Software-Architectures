using MediatR;

namespace BillingSystem.BL.Commands.InvoiceCommands;

public record DeleteInvoiceCommand(int Id) : IRequest<bool>;
