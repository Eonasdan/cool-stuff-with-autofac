using Autofac;
using CoolStuff.Business.Interfaces;
using JetBrains.Annotations;

namespace CoolStuff.FedEx;

[UsedImplicitly]
public class FedExModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<FedExClient>()
            .As<IShippingProvider>()
            .Keyed<IShippingProvider>(FedExClient.ProviderName);
    }
}