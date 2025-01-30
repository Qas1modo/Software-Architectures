using AutoMapper;
using BillingSystem.Shared.Models.InvoiceModels;

namespace BillingSystem.Application.Invoice.Profiles;

internal class InvoiceListProfile : Profile
{
    public InvoiceListProfile()
    {
        CreateMap<InvoiceListModel, Domain.Entities.Invoice.Invoice>();
    }
}
