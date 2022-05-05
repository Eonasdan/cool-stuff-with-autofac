using Autofac;
using AutoMapper;
using CoolStuff.Business;

namespace CoolStuffTests.Extensions;

public static class MockExtensions
{
    private static readonly IMapper Mapper = new MapperConfiguration(x => x.AddProfile<MapConfig>()).CreateMapper();

    public static void ProvideMapper(this ContainerBuilder mock)
    {
        mock.RegisterInstance(Mapper);
    }
}