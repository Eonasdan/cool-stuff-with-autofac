using System.Diagnostics;
using CoolStuff.Business.Models;
using CoolStuff.Business.Services;
using Microsoft.AspNetCore.Mvc;
using CoolStuff.Web.Models;

namespace CoolStuff.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IOrderService _orderService;

    public HomeController(ILogger<HomeController> logger, IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(RateQuote rateQuote)
    {
        try
        {
            ViewBag.Quote = await _orderService.GetShippingQuote(rateQuote);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "");
            ViewBag.Error = "Something went wrong";
        }
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}