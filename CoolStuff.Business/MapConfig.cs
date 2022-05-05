using AutoMapper;
using CoolStuff.Business.Models;
using JetBrains.Annotations;

namespace CoolStuff.Business;

[UsedImplicitly]
public class MapConfig : Profile
{
    public MapConfig()
    {
        CreateMap<RateQuote, OrderSummary>()
            .ForMember(summary => summary.ReceiverAddress,
                options =>
                    options.MapFrom(src => new Address
                    {
                        ZipCode = src.ReceiverZip
                    }))
            .ForMember(summary => summary.SenderAddress,
                options =>
                    options.MapFrom(src => new Address
                    {
                        ZipCode = src.SendingZip
                    }))
            .ForMember(summary => summary.OrderItems,
                options =>
                    options.MapFrom(src => new List<OrderItem>
                    {
                        new() { Weight = src.Weight }
                    }))
            .ReverseMap()
            .ForMember(rateQuote => rateQuote.Weight,
                o =>
                    o.MapFrom(src => src.OrderItems.FirstOrDefault().Weight))
            .ForMember(rateQuote => rateQuote.ReceiverZip,
                o =>
                    o.MapFrom(src => src.ReceiverAddress.ZipCode))
            .ForMember(rateQuote => rateQuote.SendingZip,
                o =>
                    o.MapFrom(src => src.SenderAddress.ZipCode));
    }
}