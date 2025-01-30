using AutoMapper;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.Shared.Models.InvoiceModels;

namespace BillingSystem.Application.Invoice.Profiles;

internal class InvoiceUpdateProfile : Profile
{
    public InvoiceUpdateProfile()
    {
        CreateMap<InvoiceUpdateModel, InvoiceEntity>();
    }
}
