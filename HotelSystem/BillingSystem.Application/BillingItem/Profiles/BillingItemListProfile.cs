using AutoMapper;
using BillingSystem.Shared.Models.BillingItem;

namespace BillingSystem.Application.BillingItem.Profiles;

internal class BillingItemListProfile : Profile
{
    public BillingItemListProfile()
    {
        CreateMap<BillingItemListModel, Domain.Entities.BillingItem.BillingItem>();
    }
}
