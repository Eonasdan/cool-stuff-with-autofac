using System.Net.Http.Headers;
using System.Text;
using CoolStuff.Business.Configurations;
using CoolStuff.Business.Interfaces;
using CoolStuff.Business.JsonHelpers;
using CoolStuff.Business.Models;
using CoolStuff.FedEx.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Address = CoolStuff.FedEx.Models.Address;

namespace CoolStuff.FedEx;

public class FedExClient : JsonBaseClient, IShippingProvider
{
    public static string ProviderName => "FedEx";
    private readonly ILogger<FedExClient> _logger;
    private readonly FedExConfiguration _configuration;
    private Token? _token;

    public FedExClient(ILogger<FedExClient> logger, IOptions<FedExConfiguration> configuration) : base("https://apis-sandbox.fedex.com")
    {
        _logger = logger;
        _configuration = configuration.Value;
    }

    internal async Task GetAuthAsync()
    {
        if (_token?.ExpiresAt > DateTime.UtcNow) return;
        
        var parameters = new Dictionary<string, string>
        {
            { "grant_type", "client_credentials" },
            { "client_id", _configuration.ApiKey },
            { "client_secret", _configuration.SecretKey }
        };
        
        var json = await PostAsync("oauth/token", new FormUrlEncodedContent(parameters));
        _token = Token.FromJson(json);
        HTTPClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token?.AccessToken);
    }

    public async Task<double> RateAsync(OrderSummary rateQuote)
    {
        var rateQuoteRequest = new RateQuoteRequest
        {
            AccountNumber = new RateQuoteAccountNumber { Value = _configuration.ShippingAccount },
            RequestedShipment = new RequestedShipment
            {
                Shipper = new Shipper
                {
                    Address = new Address
                    {
                        PostalCode = rateQuote.SenderAddress.ZipCode,
                        CountryCode = "US"
                    }
                },
                Recipient = new Shipper
                {
                    Address = new Address
                    {
                        PostalCode = rateQuote.ReceiverAddress.ZipCode,
                        CountryCode = "US"
                    }
                },
                PickupType = "DROPOFF_AT_FEDEX_LOCATION",
                RequestedPackageLineItems = new List<RequestedPackageLineItem>
                {
                    new()
                    {
                        Weight = new Weight
                        {
                            Units = "LB",
                            Value = (long)rateQuote.OrderItems.FirstOrDefault().Weight
                        }
                    }
                }
            }
        };
        try
        {
            var request = rateQuoteRequest.ToJson();
            var content = new StringContent(request, Encoding.UTF8, "application/json");
            
            await GetAuthAsync();
            var json = await PostAsync("rate/v1/rates/quotes", content);
            var response = RateQuoteResponse.FromJson(json);
            var ratedShipmentDetail = response?.Output.RateReplyDetails.FirstOrDefault()?.RatedShipmentDetails
                .FirstOrDefault();
            if (ratedShipmentDetail == null) return 0;
            return Math.Round(ratedShipmentDetail.TotalNetFedExCharge, 2);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "");
            return 0;
        }
    }
}