using AutoMapper;
using BillingSystem.Shared.Models.Invoice;

namespace BillingSystem.Application.Invoice.Profiles;

internal class InvoiceCreateProfile : Profile
{
    public InvoiceCreateProfile()
    {
        CreateMap<InvoiceCreateModel, Domain.Entities.Invoice.Invoice>();
    }
}
