using CoolStuff.Business.JsonHelpers;
using Newtonsoft.Json;

namespace CoolStuff.FedEx.Models;

public class RateQuoteResponse
{
    [JsonProperty("transactionId")] public Guid TransactionId { get; set; }

    [JsonProperty("customerTransactionId")]
    public string? CustomerTransactionId { get; set; }

    [JsonProperty("output")] public Output Output { get; set; }
    
    public static RateQuoteResponse? FromJson(string json) => 
        JsonConvert.DeserializeObject<RateQuoteResponse>(json, JsonSettings.Settings);

}

public class Output
{
    [JsonProperty("rateReplyDetails")]
    public List<RateReplyDetail> RateReplyDetails { get; set; } = new();

    [JsonProperty("quoteDate")] public DateTimeOffset QuoteDate { get; set; }

    [JsonProperty("encoded")] public bool Encoded { get; set; }

    [JsonProperty("alerts")] public List<Alert> Alerts { get; set; } = new();
}

public class Alert
{
    [JsonProperty("code")] public string? Code { get; set; }

    [JsonProperty("message")] public string? Message { get; set; }

    [JsonProperty("alertType")] public string? AlertType { get; set; }
}

public class RateReplyDetail
{
    [JsonProperty("serviceType")] public string? ServiceType { get; set; }

    [JsonProperty("serviceName")] public string? ServiceName { get; set; }

    [JsonProperty("packagingType")] public string? PackagingType { get; set; }

    [JsonProperty("customerMessages")] public List<CustomerMessage> CustomerMessages { get; set; } = new();

    [JsonProperty("ratedShipmentDetails")] public List<RatedShipmentDetail> RatedShipmentDetails { get; set; } = new();

    [JsonProperty("anonymouslyAllowable", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AnonymouslyAllowable { get; set; }

    [JsonProperty("operationalDetail", NullValueHandling = NullValueHandling.Ignore)]
    public OperationalDetail OperationalDetail { get; set; }

    [JsonProperty("signatureOptionType", NullValueHandling = NullValueHandling.Ignore)]
    public string? SignatureOptionType { get; set; }

    [JsonProperty("serviceDescription", NullValueHandling = NullValueHandling.Ignore)]
    public RateReplyDetailServiceDescription ServiceDescription { get; set; }

    [JsonProperty("commit", NullValueHandling = NullValueHandling.Ignore)]
    public Commit Commit { get; set; }
}

public class Commit
{
    [JsonProperty("dateDetail")] public DateDetail DateDetail { get; set; }
}

public class DateDetail
{
    [JsonProperty("dayOfWeek")] public string? DayOfWeek { get; set; }

    [JsonProperty("dayCxsFormat")] public DateTimeOffset DayCxsFormat { get; set; }
}

public class CustomerMessage
{
    [JsonProperty("code")] public string? Code { get; set; }

    [JsonProperty("message")] public string? Message { get; set; }
}

public class OperationalDetail
{
    [JsonProperty("originLocationIds")] public string? OriginLocationIds { get; set; }

    [JsonProperty("commitDays", NullValueHandling = NullValueHandling.Ignore)]
    public string? CommitDays { get; set; }

    [JsonProperty("serviceCode")] public string? ServiceCode { get; set; }

    [JsonProperty("airportId")] public string? AirportId { get; set; }

    [JsonProperty("scac", NullValueHandling = NullValueHandling.Ignore)]
    public string? Scac { get; set; }

    [JsonProperty("originServiceAreas")] public string? OriginServiceAreas { get; set; }

    [JsonProperty("deliveryDay")] public string? DeliveryDay { get; set; }

    [JsonProperty("originLocationNumbers")]
    public long OriginLocationNumbers { get; set; }

    [JsonProperty("destinationPostalCode")]
    [JsonConverter(typeof(StringLongConverter))]
    public long DestinationPostalCode { get; set; }

    [JsonProperty("commitDate", NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? CommitDate { get; set; }

    [JsonProperty("astraDescription")] public string? AstraDescription { get; set; }

    [JsonProperty("deliveryDate", NullValueHandling = NullValueHandling.Ignore)]
    public string? DeliveryDate { get; set; }

    [JsonProperty("deliveryEligibilities", NullValueHandling = NullValueHandling.Ignore)]
    public string? DeliveryEligibilities { get; set; }

    [JsonProperty("ineligibleForMoneyBackGuarantee")]
    public bool IneligibleForMoneyBackGuarantee { get; set; }

    [JsonProperty("maximumTransitTime", NullValueHandling = NullValueHandling.Ignore)]
    public string? MaximumTransitTime { get; set; }

    [JsonProperty("astraPlannedServiceLevel", NullValueHandling = NullValueHandling.Ignore)]
    public string? AstraPlannedServiceLevel { get; set; }

    [JsonProperty("destinationLocationIds")]
    public string? DestinationLocationIds { get; set; }

    [JsonProperty("destinationLocationStateOrProvinceCodes")]
    public string? DestinationLocationStateOrProvinceCodes { get; set; }

    [JsonProperty("transitTime")] public string? TransitTime { get; set; }

    [JsonProperty("packagingCode")] public string? PackagingCode { get; set; }

    [JsonProperty("destinationLocationNumbers")]
    public long DestinationLocationNumbers { get; set; }

    [JsonProperty("publishedDeliveryTime")]
    public DateTimeOffset PublishedDeliveryTime { get; set; }

    [JsonProperty("countryCodes")] public string? CountryCodes { get; set; }

    [JsonProperty("stateOrProvinceCodes")] public string? StateOrProvinceCodes { get; set; }

    [JsonProperty("ursaPrefixCode")]
    [JsonConverter(typeof(StringLongConverter))]
    public long UrsaPrefixCode { get; set; }

    [JsonProperty("ursaSuffixCode")] public string? UrsaSuffixCode { get; set; }

    [JsonProperty("destinationServiceAreas")]
    public string? DestinationServiceAreas { get; set; }

    [JsonProperty("originPostalCodes")]
    [JsonConverter(typeof(StringLongConverter))]
    public long OriginPostalCodes { get; set; }

    [JsonProperty("customTransitTime", NullValueHandling = NullValueHandling.Ignore)]
    public string? CustomTransitTime { get; set; }
}

public class RatedShipmentDetail
{
    [JsonProperty("rateType")] public string? RateType { get; set; }

    [JsonProperty("ratedWeightMethod")] public string? RatedWeightMethod { get; set; }

    [JsonProperty("totalDiscounts")] public double TotalDiscounts { get; set; }

    [JsonProperty("totalBaseCharge")] public double TotalBaseCharge { get; set; }

    [JsonProperty("totalNetCharge")] public double TotalNetCharge { get; set; }

    [JsonProperty("totalVatCharge")] public long TotalVatCharge { get; set; }

    [JsonProperty("totalNetFedExCharge")] public double TotalNetFedExCharge { get; set; }

    [JsonProperty("totalDutiesAndTaxes")] public long TotalDutiesAndTaxes { get; set; }

    [JsonProperty("totalNetChargeWithDutiesAndTaxes")]
    public double TotalNetChargeWithDutiesAndTaxes { get; set; }

    [JsonProperty("totalDutiesTaxesAndFees")]
    public long TotalDutiesTaxesAndFees { get; set; }

    [JsonProperty("totalAncillaryFeesAndTaxes")]
    public long TotalAncillaryFeesAndTaxes { get; set; }

    [JsonProperty("shipmentRateDetail")] public ShipmentRateDetail ShipmentRateDetail { get; set; }

    [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
    public string? Currency { get; set; }

    [JsonProperty("ratedPackages", NullValueHandling = NullValueHandling.Ignore)]
    public List<RatedPackage> RatedPackages { get; set; }

    [JsonProperty("anonymouslyAllowable", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AnonymouslyAllowable { get; set; }

    [JsonProperty("operationalDetail", NullValueHandling = NullValueHandling.Ignore)]
    public OperationalDetail OperationalDetail { get; set; }

    [JsonProperty("signatureOptionType", NullValueHandling = NullValueHandling.Ignore)]
    public string? SignatureOptionType { get; set; }

    [JsonProperty("serviceDescription", NullValueHandling = NullValueHandling.Ignore)]
    public RatedShipmentDetailServiceDescription ServiceDescription { get; set; }
}

public class RatedPackage
{
    [JsonProperty("groupNumber")] public long GroupNumber { get; set; }

    [JsonProperty("effectiveNetDiscount")] public double EffectiveNetDiscount { get; set; }

    [JsonProperty("packageRateDetail")] public PackageRateDetail PackageRateDetail { get; set; }

    [JsonProperty("rateType", NullValueHandling = NullValueHandling.Ignore)]
    public string? RateType { get; set; }

    [JsonProperty("ratedWeightMethod", NullValueHandling = NullValueHandling.Ignore)]
    public string? RatedWeightMethod { get; set; }

    [JsonProperty("baseCharge", NullValueHandling = NullValueHandling.Ignore)]
    public double? BaseCharge { get; set; }

    [JsonProperty("netFreight", NullValueHandling = NullValueHandling.Ignore)]
    public double? NetFreight { get; set; }

    [JsonProperty("totalSurcharges", NullValueHandling = NullValueHandling.Ignore)]
    public double? TotalSurcharges { get; set; }

    [JsonProperty("netFedExCharge", NullValueHandling = NullValueHandling.Ignore)]
    public double? NetFedExCharge { get; set; }

    [JsonProperty("totalTaxes", NullValueHandling = NullValueHandling.Ignore)]
    public long? TotalTaxes { get; set; }

    [JsonProperty("netCharge", NullValueHandling = NullValueHandling.Ignore)]
    public double? NetCharge { get; set; }

    [JsonProperty("totalRebates", NullValueHandling = NullValueHandling.Ignore)]
    public long? TotalRebates { get; set; }

    [JsonProperty("billingWeight\"", NullValueHandling = NullValueHandling.Ignore)]
    public BillingWeight RatedPackageBillingWeight { get; set; }

    [JsonProperty("totalFreightDiscounts", NullValueHandling = NullValueHandling.Ignore)]
    public long? TotalFreightDiscounts { get; set; }

    [JsonProperty("surcharges", NullValueHandling = NullValueHandling.Ignore)]
    public List<Surcharge> Surcharges { get; set; }

    [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
    public string? Currency { get; set; }

    [JsonProperty("billingWeight", NullValueHandling = NullValueHandling.Ignore)]
    public BillingWeight BillingWeight { get; set; }
}

public class BillingWeight
{
    [JsonProperty("units")] public string? Units { get; set; }

    [JsonProperty("value")] public long Value { get; set; }
}

public class PackageRateDetail
{
    [JsonProperty("rateType")] public string? RateType { get; set; }

    [JsonProperty("ratedWeightMethod")] public string? RatedWeightMethod { get; set; }

    [JsonProperty("baseCharge")] public double BaseCharge { get; set; }

    [JsonProperty("netFreight")] public double NetFreight { get; set; }

    [JsonProperty("totalSurcharges")] public double TotalSurcharges { get; set; }

    [JsonProperty("netFedExCharge")] public double NetFedExCharge { get; set; }

    [JsonProperty("totalTaxes")] public long TotalTaxes { get; set; }

    [JsonProperty("netCharge")] public double NetCharge { get; set; }

    [JsonProperty("totalRebates")] public long TotalRebates { get; set; }

    [JsonProperty("billingWeight")] public BillingWeight BillingWeight { get; set; }

    [JsonProperty("totalFreightDiscounts")]
    public long TotalFreightDiscounts { get; set; }

    [JsonProperty("surcharges")] public List<Surcharge> Surcharges { get; set; }

    [JsonProperty("currency")] public string? Currency { get; set; }
}

public class Surcharge
{
    [JsonProperty("type")] public string? Type { get; set; }

    [JsonProperty("description")] public string? Description { get; set; }

    [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
    public string? Level { get; set; }

    [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
    public double? Amount { get; set; }

    [JsonProperty("amount\"", NullValueHandling = NullValueHandling.Ignore)]
    public double? SurchargeAmount { get; set; }
}

public class RatedShipmentDetailServiceDescription
{
    [JsonProperty("serviceId")] public string? ServiceId { get; set; }

    [JsonProperty("serviceType")] public string? ServiceType { get; set; }

    [JsonProperty("code")]
    [JsonConverter(typeof(StringLongConverter))]
    public long Code { get; set; }

    [JsonProperty("names")] public List<Name> Names { get; set; }

    [JsonProperty("operatingOrgCodes")] public List<string> OperatingOrgCodes { get; set; }

    [JsonProperty("description")] public string? Description { get; set; }

    [JsonProperty("astraDescription")] public string? AstraDescription { get; set; }
}

public class Name
{
    [JsonProperty("type")] public string? Type { get; set; }

    [JsonProperty("encoding")] public string? Encoding { get; set; }

    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public string? Value { get; set; }

    [JsonProperty("value\"", NullValueHandling = NullValueHandling.Ignore)]
    public string? NameValue { get; set; }
}

public class ShipmentRateDetail
{
    [JsonProperty("rateZone")] public string? RateZone { get; set; }

    [JsonProperty("dimDivisor")] public long DimDivisor { get; set; }

    [JsonProperty("fuelSurchargePercent")] public double FuelSurchargePercent { get; set; }

    [JsonProperty("totalSurcharges")] public double TotalSurcharges { get; set; }

    [JsonProperty("totalFreightDiscount")] public long TotalFreightDiscount { get; set; }

    [JsonProperty("surCharges")] public List<Surcharge> SurCharges { get; set; }

    [JsonProperty("pricingCode", NullValueHandling = NullValueHandling.Ignore)]
    public string? PricingCode { get; set; }

    [JsonProperty("currencyExchangeRate", NullValueHandling = NullValueHandling.Ignore)]
    public CurrencyExchangeRate CurrencyExchangeRate { get; set; }

    [JsonProperty("totalBillingWeight", NullValueHandling = NullValueHandling.Ignore)]
    public TotalBillingWeight TotalBillingWeight { get; set; }

    [JsonProperty("currency")] public string?  Currency { get; set; }

    [JsonProperty("totalBillingWeight\"", NullValueHandling = NullValueHandling.Ignore)]
    public BillingWeight ShipmentRateDetailTotalBillingWeight { get; set; }
}

public class CurrencyExchangeRate
{
    [JsonProperty("fromCurrency")] public string?  FromCurrency { get; set; }

    [JsonProperty("intoCurrency")] public string?  IntoCurrency { get; set; }

    [JsonProperty("rate")] public double Rate { get; set; }
}

public class TotalBillingWeight
{
    [JsonProperty("units")] public string? Units { get; set; }
    
    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public long? Value { get; set; }
}

public class RateReplyDetailServiceDescription
{
    [JsonProperty("serviceId")] public string? ServiceId { get; set; }

    [JsonProperty("serviceType")] public string? ServiceType { get; set; }

    [JsonProperty("code")] public string? Code { get; set; }

    [JsonProperty("names")] public List<Name> Names { get; set; }

    [JsonProperty("operatingOrgCodes")] public List<string> OperatingOrgCodes { get; set; }

    [JsonProperty("serviceCategory")] public string? ServiceCategory { get; set; }

    [JsonProperty("description")] public string? Description { get; set; }

    [JsonProperty("astraDescription")] public string? AstraDescription { get; set; }
}