using HotelServiceSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelServiceSystem.DAL.Infrastructure.QueryObjects.Interfaces;

public interface IGetAllRoomServiceItemsQueryObject<TEntity> : IQueryObject<TEntity> where TEntity : class, new()
{
    IQueryObject<TEntity> FilterByName(string name);

    IQueryObject<TEntity> FilterByPrice(decimal minPrice, decimal maxPrice);
}
