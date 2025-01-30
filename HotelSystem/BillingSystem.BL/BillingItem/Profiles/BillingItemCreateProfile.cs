using AutoMapper;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.Shared.Models.BillingItemModels;

namespace BillingSystem.Application.BillingItem.Profiles;

internal class BillingItemCreateProfile : Profile
{
    public BillingItemCreateProfile()
    {
        CreateMap<BillingItemCreateModel, BillingItemEntity>();
    }
}
