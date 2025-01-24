using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Domain.Repositories;

public interface IPremiumServiceRepository
{
    void Insert(PremiumService premiumService);

    void Update(PremiumService premiumService);
}


