using AutoMapper;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.Shared.Models.InvoiceModels;

namespace BillingSystem.BL.Profiles.InvoiceProfiles;

internal class InvoiceDetailProfile : Profile
{
    public InvoiceDetailProfile()
    {
        CreateMap<InvoiceEntity, InvoiceDetailModel> ();
    }
}
