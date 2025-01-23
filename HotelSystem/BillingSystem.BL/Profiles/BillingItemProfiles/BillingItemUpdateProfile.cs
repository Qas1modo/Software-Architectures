using AutoMapper;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.Shared.Models.BillingItemModels;

namespace BillingSystem.BL.Profiles.BillingItemProfiles;

internal class BillingItemUpdateProfile : Profile
{
    public BillingItemUpdateProfile()
    {
        CreateMap<BillinItemUpdateModel, BillingItemEntity>();
    }
}
