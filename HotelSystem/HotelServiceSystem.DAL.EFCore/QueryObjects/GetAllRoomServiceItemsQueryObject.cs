using HotelServiceSystem.DAL.EFCore.Database;
using HotelServiceSystem.DAL.EFCore.Entities;
using HotelServiceSystem.DAL.EFCore.QueryObjects.Base;
using HotelServiceSystem.DAL.EFCore.QueryObjects.QueryObjectExceptions;
using HotelServiceSystem.DAL.Infrastructure.QueryObjects.Interfaces;
using HotelServiceSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;

namespace HotelServiceSystem.DAL.EFCore.QueryObjects;

public class GetAllRoomServiceItemsQueryObject : EFCoreQueryObject<RoomServiceItemEntity>, IGetAllRoomServiceItemsQueryObject<RoomServiceItemEntity>
{

    public GetAllRoomServiceItemsQueryObject(ApplicationDbContext dbContext) : base(dbContext) { }

    public IQueryObject<RoomServiceItemEntity> FilterByName(string itemName)
    {
        Filter(roomService => roomService.Name.Contains(itemName.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase));
        return this;
    }

    public IQueryObject<RoomServiceItemEntity> FilterByPrice(decimal minPrice, decimal maxPrice)
    {
        Filter(roomService => roomService.Price >= minPrice && roomService.Price <= maxPrice);
        return this;
    }

    public override Task<IEnumerable<RoomServiceItemEntity>> ExecuteAsync()
    {
        return base.ExecuteAsync();
    }
}
