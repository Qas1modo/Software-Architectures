using AutoMapper;
using BillingSystem.Shared.Models.BillingItem;

namespace BillingSystem.Application.BillingItem.Profiles;

internal class BillingItemCreateProfile : Profile
{
    public BillingItemCreateProfile()
    {
        CreateMap<BillingItemCreateModel, Domain.Entities.BillingItem.BillingItemEntity>();
    }
}
