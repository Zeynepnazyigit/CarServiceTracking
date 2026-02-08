using AutoMapper;
using CarServiceTracking.Core.DTOs.ListItemDTOs;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Mapping
{
    public class ListItemProfile : Profile
    {
        public ListItemProfile()
        {
            CreateMap<ListItem, ListItemListDTO>();
            CreateMap<ListItem, ListItemDetailDTO>();
            CreateMap<ListItemCreateDTO, ListItem>();
            CreateMap<ListItemUpdateDTO, ListItem>();
        }
    }
}
