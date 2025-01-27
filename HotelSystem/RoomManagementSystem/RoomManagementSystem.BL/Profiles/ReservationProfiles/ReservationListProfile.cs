using AutoMapper;
using RoomManagementSystem.Contracts;
using RoomManagementSystem.DAL.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagementSystem.BL.Profiles.ReservationProfiles
{
    internal class ReservationListProfile : Profile
    {
        public ReservationListProfile()
        {
            CreateMap<ReservationListModel, ReservationEntity>();
        }
    }
}
