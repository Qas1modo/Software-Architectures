using AutoMapper;
using BillingSystem.Shared.Models.InvoiceModels;

namespace BillingSystem.Application.Invoice.Profiles;

internal class InvoiceDetailProfile : Profile
{
    public InvoiceDetailProfile()
    {
        CreateMap<Domain.Entities.Invoice.Invoice, InvoiceDetailModel>();
    }
}
