using AutoMapper;
using BillingSystem.Shared.Models.BillingItem;

namespace BillingSystem.Application.BillingItem.Profiles;

internal class BillingItemUpdateProfile : Profile
{
    public BillingItemUpdateProfile()
    {
        CreateMap<BillinItemUpdateModel, Domain.Entities.BillingItem.BillingItem>();
    }
}
