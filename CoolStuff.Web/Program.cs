using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using CoolStuff.Business.Configurations;
using CoolStuff.Business.Extensions;
using CoolStuff.Web.Middlware;
using ElmahCore;
using ElmahCore.Mvc;
using Module = Autofac.Module;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddElmah<XmlFileErrorLog>(options =>
{
    options.LogPath = "~/log"; // OR options.LogPath = "с:\errors";
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(ConfigureContainer);

builder.Services.Configure<FedExConfiguration>(builder.Configuration.GetSection("FedEx"));
builder.Services.Configure<USPSConfiguration>(builder.Configuration.GetSection("USPS"));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseElmah();

app.Run();

static void ConfigureContainer(ContainerBuilder builder)
{
    var assemblies = AppDomain.CurrentDomain.GetAssemblies()
        .Where(x => x.FullName != null && x.FullName.StartsWith(nameof(CoolStuff))).ToList();


    new DirectoryInfo(Path.GetDirectoryName(typeof(Program).Assembly.Location)!)
        .GetFiles($"{nameof(CoolStuff)}*.dll")
        .Where(x => !assemblies.Select(y => y.ManifestModule.Name).Contains(x.Name))
        .ToList()
        .ForEach(x =>
        {
            var assembly = Assembly.LoadFile(x.FullName);
            assemblies.Add(assembly);
        });
    
    
    var assembliesTypes = assemblies.SelectMany(x => x.SafeLoadTypes()).ToList();
    
    assembliesTypes.Where(x => x.IsSubclassOf(typeof(Module))).ToList()
        .ForEach(t =>
        {
            var instance = Activator.CreateInstance(t);
            if (instance is not Module module) return;

            builder.RegisterModule(module);
        });

    var mapperConfiguration = new MapperConfiguration(cfg =>
    {
        cfg.AddCollectionMappers();

        cfg.AddMaps(assemblies);
    });

    builder.Register<IMapper>(_ => new Mapper(mapperConfiguration));
}