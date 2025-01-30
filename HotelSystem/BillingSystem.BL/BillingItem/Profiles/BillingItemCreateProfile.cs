using AutoMapper;
using BillingSystem.Shared.Models.BillingItemModels;

namespace BillingSystem.Application.BillingItem.Profiles;

internal class BillingItemCreateProfile : Profile
{
    public BillingItemCreateProfile()
    {
        CreateMap<BillingItemCreateModel, Domain.Entities.BillingItem.BillingItem>();
    }
}
