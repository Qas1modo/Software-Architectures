using AutoMapper;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.Shared.Models.InvoiceModels;

namespace BillingSystem.BL.Profiles.InvoiceProfiles;

internal class InvoiceCreateProfile : Profile
{
    public InvoiceCreateProfile()
    {
        CreateMap<InvoiceCreateModel, InvoiceEntity>();
    }
}
