using BillingSystem.Shared.Models.Invoice;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace BillingSystem.Application.Invoice.Queries;

public record GetInvoiceQuery(Guid InvoiceId) : IQuery<Maybe<InvoiceDetailModel>>;
