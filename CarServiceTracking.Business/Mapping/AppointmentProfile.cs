using AutoMapper;
using CarServiceTracking.Core.DTOs.AppointmentDTOs;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Mapping
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentListDTO>();
            CreateMap<Appointment, AppointmentDetailDTO>();
            CreateMap<AppointmentCreateDTO, Appointment>();
            CreateMap<AppointmentUpdateDTO, Appointment>();
        }
    }
}
