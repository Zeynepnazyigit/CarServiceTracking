using AutoMapper;
using CarServiceTracking.Core.DTOs.InvoiceDTOs;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Mapping
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceListDTO>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.GrandTotal));

            CreateMap<Invoice, InvoiceDetailDTO>();

            CreateMap<InvoiceCreateDTO, Invoice>()
                .ForMember(dest => dest.PaymentStatus, opt => opt.Ignore())
                .ForMember(dest => dest.PaidAmount, opt => opt.Ignore())
                .ForMember(dest => dest.RemainingAmount, opt => opt.Ignore())
                .ForMember(dest => dest.SubTotal, opt => opt.Ignore())
                .ForMember(dest => dest.TaxAmount, opt => opt.Ignore())
                .ForMember(dest => dest.GrandTotal, opt => opt.Ignore());

            CreateMap<InvoiceUpdateDTO, Invoice>();
        }
    }
}
