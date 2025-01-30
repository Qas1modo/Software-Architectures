
using AutoMapper;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.DAL.EFCore.Entities;

namespace RoomManagementSystem.BL.Profiles.RoomProfiles
{
    internal class RoomUpdateProfile : Profile
    {
        public RoomUpdateProfile()
        {
            CreateMap<RoomUpdateModel, RoomEntity>().ReverseMap();
        }
    }
}
