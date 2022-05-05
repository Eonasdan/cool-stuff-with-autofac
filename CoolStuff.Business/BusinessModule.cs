using Autofac;
using CoolStuff.Business.Interfaces;
using CoolStuff.Business.Services;
using JetBrains.Annotations;

namespace CoolStuff.Business;

[UsedImplicitly]
public class BusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(BusinessModule).Assembly)
            .Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
        
        builder.Register<Func<string, IShippingProvider>>(c =>
        {
            var componentContext = c.Resolve<IComponentContext>();
            return adapterName => componentContext.ResolveKeyed<IShippingProvider>(adapterName);
        });

        builder.RegisterType<ShippingProviderAdapter>().AsImplementedInterfaces();
    }
}