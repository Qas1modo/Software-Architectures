using BillingSystem.Domain.Core;
using BillingSystem.Domain.Entities.Invoice.ValueObjects;
using BillingSystem.Shared.Models.Invoice;

namespace BillingSystem.Domain.Entities.Invoice;

public class InvoiceEntity : BillingSystemAggregateRoot
{
    public CustomerId CustomerId { get; set; }

    public FinalPrice FinalPrice { get; set; }

    public CurrencyCode CurrencyCode { get; set; }

    public PaymentId PaymentId { get; set; }

    public IsPaid IsPaid { get; set; }

    // For EF.Core
    public InvoiceEntity() { }

    public InvoiceEntity(decimal finalPrice, string currencyCode, Guid customerId)
    {
        FinalPrice = FinalPrice.Create(finalPrice);
        CurrencyCode = CurrencyCode.Create(currencyCode);
        IsPaid = IsPaid.Create(false);
        CustomerId = CustomerId.Create(customerId);
    }

    public void Update(InvoiceUpdateModel invoiceUpdateModel)
    {
        if (invoiceUpdateModel.FinalPrice is decimal newFinalValue)
        {
            FinalPrice = FinalPrice.Create(newFinalValue);
        }

        if (invoiceUpdateModel.CurrencyCode is string newCurrencyCode)
        {
            CurrencyCode = CurrencyCode.Create(newCurrencyCode);
        }

        if (invoiceUpdateModel.PaymentId is string newPaymentId)
        {
            PaymentId = PaymentId.Create(newPaymentId);
        }

        if (invoiceUpdateModel.IsPaid is bool newIsPaid)
        {
            IsPaid = IsPaid.Create(newIsPaid);
        }
    }
}
