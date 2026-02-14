using AutoMapper;
using CarServiceTracking.Core.DTOs.PaymentDTOs;
using CarServiceTracking.Core.Entities;

namespace CarServiceTracking.Business.Mapping
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentListDTO>()
                .ForMember(dest => dest.ReferenceNumber, opt => opt.MapFrom(src => src.TransactionId ?? src.Reference));
            CreateMap<Payment, PaymentDetailDTO>();
            CreateMap<PaymentCreateDTO, Payment>();
            CreateMap<PaymentUpdateDTO, Payment>();
        }
    }
}
