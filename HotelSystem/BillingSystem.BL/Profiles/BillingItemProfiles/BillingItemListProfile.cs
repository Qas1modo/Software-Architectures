using AutoMapper;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.Shared.Models.BillingItemModels;

namespace BillingSystem.BL.Profiles.BillingItemProfiles;

internal class BillingItemListProfile : Profile
{
    public BillingItemListProfile()
    {
        CreateMap<BillingItemListModel, BillingItemEntity>();
    }
}
