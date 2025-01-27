using RoomManagementSystem.Contracts;
using RoomManagementSystem.DAL.EFCore.Entities;
using AutoMapper;

namespace RoomManagementSystem.BL.Profiles.ReservationProfiles
{
    internal class ReservationUpdateProfile : Profile
    {
        public ReservationUpdateProfile() { 
            CreateMap<ReservationUpdateModel, ReservationEntity>();
        }
    }
}
