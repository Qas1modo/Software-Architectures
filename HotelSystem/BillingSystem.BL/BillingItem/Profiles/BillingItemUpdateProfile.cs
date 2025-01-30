using AutoMapper;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.Shared.Models.BillingItemModels;

namespace BillingSystem.Application.BillingItem.Profiles;

internal class BillingItemUpdateProfile : Profile
{
    public BillingItemUpdateProfile()
    {
        CreateMap<BillinItemUpdateModel, BillingItemEntity>();
    }
}
