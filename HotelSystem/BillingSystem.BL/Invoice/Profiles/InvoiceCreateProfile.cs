using AutoMapper;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.Shared.Models.InvoiceModels;

namespace BillingSystem.Application.Invoice.Profiles;

internal class InvoiceCreateProfile : Profile
{
    public InvoiceCreateProfile()
    {
        CreateMap<InvoiceCreateModel, InvoiceEntity>();
    }
}
