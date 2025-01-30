using AutoMapper;
using BillingSystem.Shared.Models.BillingItemModels;

namespace BillingSystem.Application.BillingItem.Profiles;

internal class BillingItemListProfile : Profile
{
    public BillingItemListProfile()
    {
        CreateMap<BillingItemListModel, Domain.Entities.BillingItem.BillingItem>();
    }
}
