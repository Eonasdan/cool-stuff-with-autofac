using Autofac;
using CoolStuff.Business.Interfaces;
using JetBrains.Annotations;

namespace CoolStuff.USPS;

[UsedImplicitly]
public class USPSModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<USPSClient>()
            .As<IShippingProvider>()
            .Keyed<IShippingProvider>(USPSClient.ProviderName);
    }
}