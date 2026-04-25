using AutoMapper;
using InsureTrust.API.Models;
using InsureTrust.API.DTOs.Payment;

namespace InsureTrust.API.Mappings;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<Payment, PaymentDto>()
            .ForMember(dest => dest.PolicyNumber, opt => opt.MapFrom(src => $"POL-{src.UserPolicyId}"));
        
        CreateMap<InitiatePaymentDto, Payment>()
            .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Success"));
    }
}
