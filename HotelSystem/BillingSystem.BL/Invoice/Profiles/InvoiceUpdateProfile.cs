using AutoMapper;
using BillingSystem.Shared.Models.InvoiceModels;

namespace BillingSystem.Application.Invoice.Profiles;

internal class InvoiceUpdateProfile : Profile
{
    public InvoiceUpdateProfile()
    {
        CreateMap<InvoiceUpdateModel, Domain.Entities.Invoice.Invoice>();
    }
}
