using AutoMapper;
using BillingSystem.Shared.Models.BillingItemModels;

namespace BillingSystem.Application.BillingItem.Profiles;

internal class BillingItemDetailProfile : Profile
{
    public BillingItemDetailProfile()
    {
        CreateMap<Domain.Entities.BillingItem.BillingItem, BillingItemDetailModel>();
    }
}
