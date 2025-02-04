using AutoMapper;
using BillingSystem.Shared.Models.Invoice;

namespace BillingSystem.Application.Invoice.Profiles;

internal class InvoiceUpdateProfile : Profile
{
    public InvoiceUpdateProfile()
    {
        CreateMap<InvoiceUpdateModel, Domain.Entities.Invoice.InvoiceEntity>();
    }
}
