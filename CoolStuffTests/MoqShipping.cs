using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using CoolStuff.Business.Interfaces;
using CoolStuff.Business.Models;
using CoolStuff.Business.Services;
using Moq;

namespace CoolStuffTests;

public static class MoqShipping
{
    public const double QuotePrice = 454.47;

    public static readonly RateQuote RateQuote = new()
    {
        Shipper = "Mock",
        ReceiverZip = "20004",
        SendingZip = "95501",
        Weight = 42
    };

    public static readonly OrderSummary OrderSummary = new()
    {
        ReceiverAddress = new Address
        {
            ZipCode = RateQuote.ReceiverZip
        },
        SenderAddress = new Address
        {
            ZipCode = RateQuote.SendingZip
        },
        OrderItems = new List<OrderItem>
        {
            new() { Weight = RateQuote.Weight }
        }
    };

    public static Mock<IShippingProviderAdapter> ShippingProviderAdapter(this AutoMock mock)
    {
        var shippingProvider = mock.Mock<IShippingProviderAdapter>();

        shippingProvider
            .Setup(x => x.Get(It.IsAny<string>()))
            .Returns(mock.ShippingProvider().Object);

        return shippingProvider;
    }

    public static Mock<IShippingProvider> ShippingProvider(this AutoMock mock)
    {
        var shippingProvider = mock.Mock<IShippingProvider>();

        shippingProvider
            .Setup(x => x.RateAsync(It.IsAny<OrderSummary>()))
            .Returns(Task.FromResult(QuotePrice));

        return shippingProvider;
    }
}