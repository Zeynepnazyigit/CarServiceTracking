using AutoMapper;
using CarServiceTracking.Core.DTOs.PartDTOs;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Mapping
{
    public class PartProfile : Profile
    {
        public PartProfile()
        {
            CreateMap<Part, PartListDTO>();
            CreateMap<Part, PartDetailDTO>();
            CreateMap<PartCreateDTO, Part>();
            CreateMap<PartUpdateDTO, Part>();
        }
    }
}
