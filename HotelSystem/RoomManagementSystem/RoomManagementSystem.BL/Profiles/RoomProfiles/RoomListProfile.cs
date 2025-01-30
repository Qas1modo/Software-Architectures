using AutoMapper;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.DAL.EFCore.Entities;

namespace RoomManagementSystem.BL.Profiles.RoomProfiles
{
    internal class RoomListProfile : Profile
    {
        public RoomListProfile()
        {
            CreateMap<RoomListModel, RoomEntity>().ReverseMap();
        }
    }
}
