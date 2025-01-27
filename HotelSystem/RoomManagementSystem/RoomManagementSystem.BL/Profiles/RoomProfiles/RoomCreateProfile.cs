using AutoMapper;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.DAL.EFCore.Entities;

namespace RoomManagementSystem.BL.Profiles.RoomProfiles
{
    internal class RoomCreateProfile : Profile
    {
        public RoomCreateProfile()
        {
            CreateMap<RoomCreateModel, RoomEntity>();
        }
    }
}
