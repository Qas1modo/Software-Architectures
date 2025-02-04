using AutoMapper;
using BillingSystem.Shared.Models.BillingItem;

namespace BillingSystem.Application.BillingItem.Profiles;

internal class BillingItemDetailProfile : Profile
{
    public BillingItemDetailProfile()
    {
        CreateMap<Domain.Entities.BillingItem.BillingItemEntity, BillingItemDetailModel>();
    }
}
