using AutoMapper;
using CarServiceTracking.Core.DTOs.InvoiceDTOs;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Mapping
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceListDTO>();
            CreateMap<Invoice, InvoiceDetailDTO>();
            CreateMap<InvoiceCreateDTO, Invoice>();
            CreateMap<InvoiceUpdateDTO, Invoice>();
        }
    }
}
