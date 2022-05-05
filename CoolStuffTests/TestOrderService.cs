using System.Threading.Tasks;
using Autofac.Extras.Moq;
using CoolStuff.Business.Models;
using CoolStuff.Business.Services;
using CoolStuffTests.Extensions;
using Moq;
using Xunit;

namespace CoolStuffTests;

public class TestOrderService
{
    [Fact]
    public async Task GettingShippingQuote_ShouldReturnRate()
    {
        using var mock = AutoMock.GetLoose(cfg => { cfg.ProvideMapper(); });
        var shippingProviderAdapter = mock.ShippingProviderAdapter();

        var systemUnderTest = mock.Create<OrderService>();

        var actual = await systemUnderTest.GetShippingQuote(MoqShipping.RateQuote);
        
        Assert.True(actual == MoqShipping.QuotePrice);
        shippingProviderAdapter.Verify(x => x.Get(It.IsAny<string>()));
        shippingProviderAdapter
            .Verify(x => x.Get(It.IsAny<string>())
                .RateAsync(It.IsAny<OrderSummary>()));
    }
}