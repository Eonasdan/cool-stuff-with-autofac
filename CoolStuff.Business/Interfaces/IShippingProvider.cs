using CoolStuff.Business.Models;

namespace CoolStuff.Business.Interfaces;

public interface IShippingProvider
{
    Task<double> RateAsync(OrderSummary rateQuote);
}