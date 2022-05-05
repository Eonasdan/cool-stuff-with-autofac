using CoolStuff.Business.Configurations;
using CoolStuff.Business.Models;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using ShippingRates;
using ShippingRates.ShippingProviders;
using Address = ShippingRates.Address;
using IShippingProvider = CoolStuff.Business.Interfaces.IShippingProvider;

namespace CoolStuff.USPS;

[UsedImplicitly]
public class USPSClient : IShippingProvider
{
    public static string ProviderName => "USPS";
    private readonly USPSConfiguration _configuration;

    public USPSClient(IOptions<USPSConfiguration> configuration)
    {
        _configuration = configuration.Value;
    }
    
    public Task<double> RateAsync(OrderSummary rateQuote)
    {
        var packages = new List<Package>
        {
            new(12, 12, 12, rateQuote.OrderItems.FirstOrDefault().Weight, 150)
        };

        var origin = new Address("", "", rateQuote.SenderAddress.ZipCode, "US");
        var destination = new Address("", "", rateQuote.ReceiverAddress.ZipCode, "US");

        var rateManager = new RateManager();
        rateManager.AddProvider(new USPSProvider(_configuration.Username));

        var shipment = rateManager.GetRates(origin, destination, packages);
        var totalCharges = shipment.Rates.FirstOrDefault()?.TotalCharges;

        return Task.FromResult((double)(totalCharges ?? 0));
    }
}