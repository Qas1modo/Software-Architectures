using AutoMapper;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.DAL.EFCore.Entities;


namespace RoomManagementSystem.BL.Profiles.ReservationProfiles
{
    internal class ReservationDetailProfile : Profile
    {
        public ReservationDetailProfile()
        {
            CreateMap<ReservationDetailModel, ReservationEntity>();
        }
    }
}
