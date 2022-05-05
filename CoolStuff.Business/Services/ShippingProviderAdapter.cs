using CoolStuff.Business.Interfaces;
using JetBrains.Annotations;

namespace CoolStuff.Business.Services;

[UsedImplicitly]
public class ShippingProviderAdapter : IShippingProviderAdapter
{
    private readonly Func<string, IShippingProvider> _shippingProviderAdapter;

    public ShippingProviderAdapter(Func<string, IShippingProvider> shippingProviderAdapter)
    {
        _shippingProviderAdapter = shippingProviderAdapter;
    }
    
    public IShippingProvider Get(string providerName)
    {
        return _shippingProviderAdapter(providerName);
    }
}

public interface IShippingProviderAdapter
{
    IShippingProvider Get(string providerName);
}