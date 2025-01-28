using HotelServiceSystem.Contracts.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace HotelServiceSystem.Contracts.Models.PremiumOrderModels;

public class GetPremiumOrdersModel
{
    [Required]
    public Guid GuestId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
