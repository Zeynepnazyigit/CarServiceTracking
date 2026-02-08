using AutoMapper;
using CarServiceTracking.Core.DTOs.MechanicDTOs;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Mapping
{
    public class MechanicProfile : Profile
    {
        public MechanicProfile()
        {
            CreateMap<Mechanic, MechanicListDTO>();
            CreateMap<Mechanic, MechanicDetailDTO>();
            CreateMap<MechanicCreateDTO, Mechanic>();
            CreateMap<MechanicUpdateDTO, Mechanic>();
        }
    }
}
