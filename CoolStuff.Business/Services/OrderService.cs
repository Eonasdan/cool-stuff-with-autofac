using AutoMapper;
using CoolStuff.Business.Models;
using JetBrains.Annotations;

namespace CoolStuff.Business.Services;

[UsedImplicitly]
public class OrderService : IOrderService
{
    private readonly IShippingProviderAdapter _shippingProviderAdapter;
    private readonly IMapper _mapper;

    public OrderService(IShippingProviderAdapter shippingProviderAdapter, IMapper mapper)
    {
        _shippingProviderAdapter = shippingProviderAdapter;
        _mapper = mapper;
    }
    
    public async Task<double> GetShippingQuote(RateQuote rateQuote)
    {
        var orderSummary = _mapper.Map<OrderSummary>(rateQuote);
        var shippingProvider = _shippingProviderAdapter.Get(rateQuote.Shipper);

        return await shippingProvider.RateAsync(orderSummary);
    }
}

public interface IOrderService
{
    Task<double> GetShippingQuote(RateQuote rateQuote);
}