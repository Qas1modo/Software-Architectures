
using AutoMapper;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.DAL.EFCore.Entities;

namespace RoomManagementSystem.BL.Profiles.RoomProfiles
{
    internal class RoomDetailProfile : Profile
    {
        public RoomDetailProfile()
        {
            CreateMap<RoomDetailModel, RoomEntity>().ReverseMap();
        }
    }
}
