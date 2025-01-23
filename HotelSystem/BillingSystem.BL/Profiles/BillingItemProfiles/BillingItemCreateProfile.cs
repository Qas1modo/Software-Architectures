using AutoMapper;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.Shared.Models.BillingItemModels;

namespace BillingSystem.BL.Profiles.BillingItemProfiles;

internal class BillingItemCreateProfile : Profile
{
    public BillingItemCreateProfile()
    {
        CreateMap<BillingItemCreateModel, BillingItemEntity>();
    }
}
