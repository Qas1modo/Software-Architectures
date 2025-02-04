using BillingSystem.Domain.Core;
using BillingSystem.Domain.Entities.Invoice.ValueObjects;
using BillingSystem.Shared.Models.Invoice;
using System.Runtime.Serialization;

namespace BillingSystem.Domain.Entities.Invoice;

public class InvoiceEntity : BillingSystemAggregateRoot
{
    [IgnoreDataMember]
    public static string TableName = "Invoices";

    public CustomerId CustomerId { get; private set; }

    public FinalPrice FinalPrice { get; private set; }

    public CurrencyCode CurrencyCode { get; private set; }

    public PaymentId PaymentId { get; private set; }

    public IsPaid IsPaid { get; private set; }

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
