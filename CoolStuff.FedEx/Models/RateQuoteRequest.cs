using CoolStuff.Business.JsonHelpers;
using Newtonsoft.Json;

namespace CoolStuff.FedEx.Models;

public class RateQuoteRequest
{
    [JsonProperty("accountNumber")] public RateQuoteAccountNumber? AccountNumber { get; set; }

    [JsonProperty("rateRequestControlParameters")]
    public RateRequestControlParameters? RateRequestControlParameters { get; set; }

    [JsonProperty("requestedShipment")] public RequestedShipment? RequestedShipment { get; set; }

    [JsonProperty("carrierCodes")] public List<string>? CarrierCodes { get; set; }
    
    public string ToJson() => JsonConvert.SerializeObject(this, JsonSettings.Settings);
}

public class RateQuoteAccountNumber
{
    [JsonProperty("value")] public string? Value { get; set; }
}

public class RateRequestControlParameters
{
    [JsonProperty("returnTransitTimes")] public bool? ReturnTransitTimes { get; set; }

    [JsonProperty("servicesNeededOnRateFailure")]
    public bool? ServicesNeededOnRateFailure { get; set; }

    [JsonProperty("variableOptions")] public string? VariableOptions { get; set; }

    [JsonProperty("rateSortOrder")] public string? RateSortOrder { get; set; }
}

public class RequestedShipment
{
    [JsonProperty("shipper")] public Shipper? Shipper { get; set; }

    [JsonProperty("recipient")] public Shipper? Recipient { get; set; }

    [JsonProperty("serviceType")] public string? ServiceType { get; set; }

    [JsonProperty("emailNotificationDetail")]
    public EmailNotificationDetail? EmailNotificationDetail { get; set; }

    [JsonProperty("preferredCurrency")] public string? PreferredCurrency { get; set; }

    [JsonProperty("rateRequestType")]
    public List<string>? RateRequestType { get; set; } = new() { "ACCOUNT" };

    [JsonProperty("shipDateStamp")] public DateTimeOffset? ShipDateStamp { get; set; }

    [JsonProperty("pickupType")] public string? PickupType { get; set; }

    [JsonProperty("requestedPackageLineItems")]
    public List<RequestedPackageLineItem>? RequestedPackageLineItems { get; set; }

    [JsonProperty("documentShipment")] public bool? DocumentShipment { get; set; }

    [JsonProperty("pickupDetail")] public PickupDetail? PickupDetail { get; set; }

    [JsonProperty("variableHandlingChargeDetail")]
    public VariableHandlingChargeDetail? VariableHandlingChargeDetail { get; set; }

    [JsonProperty("packagingType")] public string? PackagingType { get; set; }

    [JsonProperty("totalPackageCount")] public long? TotalPackageCount { get; set; }

    [JsonProperty("totalWeight")] public double? TotalWeight { get; set; }

    [JsonProperty("shipmentSpecialServices")]
    public ShipmentSpecialServices? ShipmentSpecialServices { get; set; }

    [JsonProperty("customsClearanceDetail")]
    public CustomsClearanceDetail? CustomsClearanceDetail { get; set; }

    [JsonProperty("groupShipment")] public bool? GroupShipment { get; set; }

    [JsonProperty("serviceTypeDetail")] public ServiceTypeDetail? ServiceTypeDetail { get; set; }

    [JsonProperty("smartPostInfoDetail")] public SmartPostInfoDetail? SmartPostInfoDetail { get; set; }

    [JsonProperty("expressFreightDetail")] public ExpressFreightDetail? ExpressFreightDetail { get; set; }

    [JsonProperty("groundShipment")] public bool? GroundShipment { get; set; }
}

public class CustomsClearanceDetail
{
    [JsonProperty("commercialInvoice")] public CommercialInvoice? CommercialInvoice { get; set; }

    [JsonProperty("freightOnValue")] public string? FreightOnValue { get; set; }

    [JsonProperty("dutiesPayment")] public DutiesPayment? DutiesPayment { get; set; }

    [JsonProperty("commodities")] public List<Commodity>? Commodities { get; set; }
}

public class CommercialInvoice
{
    [JsonProperty("shipmentPurpose")] public string? ShipmentPurpose { get; set; }
}

public class Commodity
{
    [JsonProperty("description")] public string? Description { get; set; }

    [JsonProperty("weight")] public Weight? Weight { get; set; }

    [JsonProperty("quantity")] public long? Quantity { get; set; }

    [JsonProperty("customsValue")] public FixedValue? CustomsValue { get; set; }

    [JsonProperty("unitPrice")] public FixedValue? UnitPrice { get; set; }

    [JsonProperty("numberOfPieces")] public long? NumberOfPieces { get; set; }

    [JsonProperty("countryOfManufacture")] public string? CountryOfManufacture { get; set; }

    [JsonProperty("quantityUnits")] public string? QuantityUnits { get; set; }

    [JsonProperty("name")] public string? Name { get; set; }

    [JsonProperty("harmonizedCode")] public string? HarmonizedCode { get; set; }

    [JsonProperty("partNumber")] public string? PartNumber { get; set; }
}

public class FixedValue
{
    [JsonProperty("amount")]
    [JsonConverter(typeof(StringLongConverter))]
    public long? Amount { get; set; }

    [JsonProperty("currency")] public string? Currency { get; set; }
}

public class Weight
{
    [JsonProperty("units")] public string? Units { get; set; }

    [JsonProperty("value")] public long? Value { get; set; }
}

public class DutiesPayment
{
    [JsonProperty("payor")] public Payor? Payor { get; set; }

    [JsonProperty("paymentType")] public string? PaymentType { get; set; }
}

public class Payor
{
    [JsonProperty("responsibleParty")] public ResponsibleParty? ResponsibleParty { get; set; }
}

public class ResponsibleParty
{
    [JsonProperty("address")] public Address? Address { get; set; }

    [JsonProperty("contact")] public ResponsiblePartyContact? Contact { get; set; }

    [JsonProperty("accountNumber")] public RateQuoteAccountNumber? AccountNumber { get; set; }
}

public class Address
{
    [JsonProperty("streetLines")] public List<string>? StreetLines { get; set; }

    [JsonProperty("city")] public string? City { get; set; }

    [JsonProperty("stateOrProvinceCode")] public string? StateOrProvinceCode { get; set; }

    [JsonProperty("postalCode")]
    public string? PostalCode { get; set; }

    [JsonProperty("countryCode")] public string? CountryCode { get; set; }

    [JsonProperty("residential")] public bool? Residential { get; set; }
}

public class ResponsiblePartyContact
{
    [JsonProperty("personName")] public string? PersonName { get; set; }

    [JsonProperty("emailAddress")] public string? EmailAddress { get; set; }

    [JsonProperty("parsedPersonName")] public ParsedPersonName? ParsedPersonName { get; set; }

    [JsonProperty("phoneNumber")] public string? PhoneNumber { get; set; }

    [JsonProperty("phoneExtension")] public string? PhoneExtension { get; set; }

    [JsonProperty("companyName")] public string? CompanyName { get; set; }

    [JsonProperty("faxNumber")] public string? FaxNumber { get; set; }
}

public class ParsedPersonName
{
    [JsonProperty("firstName")] public string? FirstName { get; set; }

    [JsonProperty("lastName")] public string? LastName { get; set; }

    [JsonProperty("middleName")] public string? MiddleName { get; set; }

    [JsonProperty("suffix")] public string? Suffix { get; set; }
}

public class EmailNotificationDetail
{
    [JsonProperty("recipients")] public List<EmailNotificationDetailRecipient>? Recipients { get; set; }

    [JsonProperty("personalMessage")] public string? PersonalMessage { get; set; }

    [JsonProperty("PrintedReference")] public PrintedReference? PrintedReference { get; set; }
}

public class PrintedReference
{
    [JsonProperty("printedReferenceType")] public string? PrintedReferenceType { get; set; }

    [JsonProperty("value")] public string? Value { get; set; }
}

public class EmailNotificationDetailRecipient
{
    [JsonProperty("emailAddress")] public string? EmailAddress { get; set; }

    [JsonProperty("notificationEventType")]
    public List<string>? NotificationEventType { get; set; }

    [JsonProperty("smsDetail")] public SmsDetail? SmsDetail { get; set; }

    [JsonProperty("notificationFormatType")]
    public string? NotificationFormatType { get; set; }

    [JsonProperty("emailNotificationRecipientType")]
    public string? EmailNotificationRecipientType { get; set; }

    [JsonProperty("notificationType")] public string? NotificationType { get; set; }

    [JsonProperty("locale")] public string? Locale { get; set; }
}

public class SmsDetail
{
    [JsonProperty("phoneNumber")] public string? PhoneNumber { get; set; }

    [JsonProperty("phoneNumberCountryCode")]
    public string? PhoneNumberCountryCode { get; set; }
}

public class ExpressFreightDetail
{
    [JsonProperty("bookingConfirmationNumber")]
    public string? BookingConfirmationNumber { get; set; }

    [JsonProperty("shippersLoadAndCount")] public long? ShippersLoadAndCount { get; set; }
}

public class PickupDetail
{
    [JsonProperty("companyCloseTime")] public string? CompanyCloseTime { get; set; }

    [JsonProperty("pickupOrigin")] public PickupOrigin? PickupOrigin { get; set; }

    [JsonProperty("geographicalPostalCode")]
    public string? GeographicalPostalCode { get; set; }

    [JsonProperty("requestType")] public string? RequestType { get; set; }

    [JsonProperty("buildingPartDescription")]
    public string? BuildingPartDescription { get; set; }

    [JsonProperty("courierInstructions")] public string? CourierInstructions { get; set; }

    [JsonProperty("buildingPart")] public string? BuildingPart { get; set; }

    [JsonProperty("latestPickupDateTime")] public string? LatestPickupDateTime { get; set; }

    [JsonProperty("packageLocation")] public string? PackageLocation { get; set; }

    [JsonProperty("readyPickupDateTime")] public string? ReadyPickupDateTime { get; set; }

    [JsonProperty("earlyPickup")] public bool? EarlyPickup { get; set; }
}

public class PickupOrigin
{
    [JsonProperty("accountNumber")] public PickupOriginAccountNumber? AccountNumber { get; set; }

    [JsonProperty("address")] public PickupOriginAddress? Address { get; set; }

    [JsonProperty("contact")] public PickupOriginContact? Contact { get; set; }
}

public class PickupOriginAccountNumber
{
    [JsonProperty("value")] public long? Value { get; set; }
}

public class PickupOriginAddress
{
    [JsonProperty("addressVerificationId")]
    public string? AddressVerificationId { get; set; }

    [JsonProperty("countryCode")] public string? CountryCode { get; set; }

    [JsonProperty("streetLines")] public List<string>? StreetLines { get; set; }
}

public class PickupOriginContact
{
    [JsonProperty("companyName")] public string? CompanyName { get; set; }

    [JsonProperty("faxNumber")] public string? FaxNumber { get; set; }

    [JsonProperty("personName")] public string? PersonName { get; set; }

    [JsonProperty("phoneNumber")] public string? PhoneNumber { get; set; }
}

public class Shipper
{
    [JsonProperty("address")] public Address? Address { get; set; }
}

public class RequestedPackageLineItem
{
    [JsonProperty("subPackagingType")] public string? SubPackagingType { get; set; }

    [JsonProperty("groupPackageCount")] public long? GroupPackageCount { get; set; }

    [JsonProperty("contentRecord")] public List<ContentRecord>? ContentRecord { get; set; }

    [JsonProperty("declaredValue")] public FixedValue? DeclaredValue { get; set; }

    [JsonProperty("weight")] public Weight? Weight { get; set; }

    [JsonProperty("dimensions")] public Dimensions? Dimensions { get; set; }

    [JsonProperty("variableHandlingChargeDetail")]
    public VariableHandlingChargeDetail? VariableHandlingChargeDetail { get; set; }

    [JsonProperty("packageSpecialServices")]
    public PackageSpecialServices? PackageSpecialServices { get; set; }
}

public class ContentRecord
{
    [JsonProperty("itemNumber")] public string? ItemNumber { get; set; }

    [JsonProperty("receivedQuantity")] public long? ReceivedQuantity { get; set; }

    [JsonProperty("description")] public string? Description { get; set; }

    [JsonProperty("partNumber")] public string? PartNumber { get; set; }
}

public class Dimensions
{
    [JsonProperty("length")] public long? Length { get; set; }

    [JsonProperty("width")] public long? Width { get; set; }

    [JsonProperty("height")] public long? Height { get; set; }

    [JsonProperty("units")] public string? Units { get; set; }
}

public class PackageSpecialServices
{
    [JsonProperty("specialServiceTypes")] public List<string>? SpecialServiceTypes { get; set; }

    [JsonProperty("alcoholDetail")] public AlcoholDetail? AlcoholDetail { get; set; }

    [JsonProperty("dangerousGoodsDetail")] public DangerousGoodsDetail? DangerousGoodsDetail { get; set; }

    [JsonProperty("packageCODDetail")] public PackageCodDetail? PackageCodDetail { get; set; }

    [JsonProperty("pieceCountVerificationBoxCount")]
    public long? PieceCountVerificationBoxCount { get; set; }

    [JsonProperty("batteryDetails")] public List<BatteryDetail>? BatteryDetails { get; set; }

    [JsonProperty("dryIceWeight")] public Weight? DryIceWeight { get; set; }
}

public class AlcoholDetail
{
    [JsonProperty("alcoholRecipientType")] public string? AlcoholRecipientType { get; set; }

    [JsonProperty("shipperAgreementType")] public string? ShipperAgreementType { get; set; }
}

public class BatteryDetail
{
    [JsonProperty("material")] public string? Material { get; set; }

    [JsonProperty("regulatorySubType")] public string? RegulatorySubType { get; set; }

    [JsonProperty("packing")] public string? Packing { get; set; }
}

public class DangerousGoodsDetail
{
    [JsonProperty("offeror")] public string? Offeror { get; set; }

    [JsonProperty("accessibility")] public string? Accessibility { get; set; }

    [JsonProperty("emergencyContactNumber")]
    public string? EmergencyContactNumber { get; set; }

    [JsonProperty("options")] public List<string>? Options { get; set; }

    [JsonProperty("containers")] public List<Container>? Containers { get; set; }

    [JsonProperty("packaging")] public Packaging? Packaging { get; set; }
}

public class Container
{
    [JsonProperty("offeror")] public string? Offeror { get; set; }

    [JsonProperty("hazardousCommodities")] public List<HazardousCommodity>? HazardousCommodities { get; set; }

    [JsonProperty("numberOfContainers")] public long? NumberOfContainers { get; set; }

    [JsonProperty("containerType")] public string? ContainerType { get; set; }

    [JsonProperty("emergencyContactNumber")]
    public Number? EmergencyContactNumber { get; set; }

    [JsonProperty("packaging")] public Packaging? Packaging { get; set; }

    [JsonProperty("packingType")] public string? PackingType { get; set; }

    [JsonProperty("radioactiveContainerClass")]
    public string? RadioactiveContainerClass { get; set; }
}

public class Number
{
    [JsonProperty("areaCode")] public string? AreaCode { get; set; }

    [JsonProperty("extension")] public string? Extension { get; set; }

    [JsonProperty("countryCode")] public string? CountryCode { get; set; }

    [JsonProperty("personalIdentificationNumber")]
    public string? PersonalIdentificationNumber { get; set; }

    [JsonProperty("localNumber")] public string? LocalNumber { get; set; }
}

public class HazardousCommodity
{
    [JsonProperty("quantity")] public Quantity? Quantity { get; set; }

    [JsonProperty("innerReceptacles")] public List<InnerReceptacle>? InnerReceptacles { get; set; }

    [JsonProperty("options")] public Options? Options { get; set; }

    [JsonProperty("description")] public Description? Description { get; set; }
}

public class Description
{
    [JsonProperty("sequenceNumber")] public long? SequenceNumber { get; set; }

    [JsonProperty("processingOptions")] public List<string>? ProcessingOptions { get; set; }

    [JsonProperty("subsidiaryClasses")] public string? SubsidiaryClasses { get; set; }

    [JsonProperty("labelText")] public string? LabelText { get; set; }

    [JsonProperty("technicalName")] public string? TechnicalName { get; set; }

    [JsonProperty("packingDetails")] public PackingDetails? PackingDetails { get; set; }

    [JsonProperty("authorization")] public string? Authorization { get; set; }

    [JsonProperty("reportableQuantity")] public bool? ReportableQuantity { get; set; }

    [JsonProperty("percentage")] public long? Percentage { get; set; }

    [JsonProperty("id")] public string? Id { get; set; }

    [JsonProperty("packingGroup")] public string? PackingGroup { get; set; }

    [JsonProperty("properShippingName")] public string? ProperShippingName { get; set; }

    [JsonProperty("hazardClass")] public string? HazardClass { get; set; }
}

public class PackingDetails
{
    [JsonProperty("packingInstructions")] public string? PackingInstructions { get; set; }

    [JsonProperty("cargoAircraftOnly")] public bool? CargoAircraftOnly { get; set; }
}

public class InnerReceptacle
{
    [JsonProperty("quantity")] public Quantity? Quantity { get; set; }
}

public class Quantity
{
    [JsonProperty("quantityType")] public string? QuantityType { get; set; }

    [JsonProperty("amount")] public long? Amount { get; set; }

    [JsonProperty("units")] public string? Units { get; set; }
}

public class Options
{
    [JsonProperty("labelTextOption")] public string? LabelTextOption { get; set; }

    [JsonProperty("customerSuppliedLabelText")]
    public string? CustomerSuppliedLabelText { get; set; }
}

public class Packaging
{
    [JsonProperty("count")] public long? Count { get; set; }

    [JsonProperty("units")] public string? Units { get; set; }
}

public class PackageCodDetail
{
    [JsonProperty("codCollectionAmount")] public CodCollectionAmount? CodCollectionAmount { get; set; }

    [JsonProperty("codCollectionType")] public string? CodCollectionType { get; set; }
}

public class CodCollectionAmount
{
    [JsonProperty("amount")] public double? Amount { get; set; }

    [JsonProperty("currency")] public string? Currency { get; set; }
}

public class VariableHandlingChargeDetail
{
    [JsonProperty("rateType")] public string? RateType { get; set; }

    [JsonProperty("percentValue")] public long? PercentValue { get; set; }

    [JsonProperty("rateLevelType")] public string? RateLevelType { get; set; }

    [JsonProperty("fixedValue")] public FixedValue? FixedValue { get; set; }

    [JsonProperty("rateElementBasis")] public string? RateElementBasis { get; set; }
}

public class ServiceTypeDetail
{
    [JsonProperty("carrierCode")] public string? CarrierCode { get; set; }

    [JsonProperty("description")] public string? Description { get; set; }

    [JsonProperty("serviceName")] public string? ServiceName { get; set; }

    [JsonProperty("serviceCategory")] public string? ServiceCategory { get; set; }
}

public class ShipmentSpecialServices
{
    [JsonProperty("returnShipmentDetail")] public ReturnShipmentDetail? ReturnShipmentDetail { get; set; }

    [JsonProperty("deliveryOnInvoiceAcceptanceDetail")]
    public DeliveryOnInvoiceAcceptanceDetail? DeliveryOnInvoiceAcceptanceDetail { get; set; }

    [JsonProperty("internationalTrafficInArmsRegulationsDetail")]
    public InternationalTrafficInArmsRegulationsDetail? InternationalTrafficInArmsRegulationsDetail { get; set; }

    [JsonProperty("pendingShipmentDetail")]
    public PendingShipmentDetail? PendingShipmentDetail { get; set; }

    [JsonProperty("holdAtLocationDetail")] public HoldAtLocationDetail? HoldAtLocationDetail { get; set; }

    [JsonProperty("shipmentCODDetail")] public ShipmentCodDetail? ShipmentCodDetail { get; set; }

    [JsonProperty("shipmentDryIceDetail")] public ShipmentDryIceDetail? ShipmentDryIceDetail { get; set; }

    [JsonProperty("internationalControlledExportDetail")]
    public InternationalControlledExportDetail? InternationalControlledExportDetail { get; set; }

    [JsonProperty("homeDeliveryPremiumDetail")]
    public HomeDeliveryPremiumDetail? HomeDeliveryPremiumDetail { get; set; }

    [JsonProperty("specialServiceTypes")] public List<string>? SpecialServiceTypes { get; set; }
}

public class DeliveryOnInvoiceAcceptanceDetail
{
    [JsonProperty("recipient")] public DeliveryOnInvoiceAcceptanceDetailRecipient? Recipient { get; set; }
}

public class DeliveryOnInvoiceAcceptanceDetailRecipient
{
    [JsonProperty("accountNumber")] public PickupOriginAccountNumber? AccountNumber { get; set; }

    [JsonProperty("address")] public PurpleAddress? Address { get; set; }

    [JsonProperty("contact")] public PickupOriginContact? Contact { get; set; }
}

public class PurpleAddress
{
    [JsonProperty("streetLines")] public List<string>? StreetLines { get; set; }

    [JsonProperty("countryCode")] public string? CountryCode { get; set; }
}

public class HoldAtLocationDetail
{
    [JsonProperty("locationId")] public string? LocationId { get; set; }

    [JsonProperty("locationContactAndAddress")]
    public TionContactAndAddress? LocationContactAndAddress { get; set; }

    [JsonProperty("locationType")] public string? LocationType { get; set; }
}

public class TionContactAndAddress
{
    [JsonProperty("address")] public Address? Address { get; set; }

    [JsonProperty("contact")] public ResponsiblePartyContact? Contact { get; set; }
}

public class HomeDeliveryPremiumDetail
{
    [JsonProperty("phoneNumber")] public Number? PhoneNumber { get; set; }

    [JsonProperty("shipTimestamp")] public DateTimeOffset? ShipTimestamp { get; set; }

    [JsonProperty("homedeliveryPremiumType")]
    public string? HomedeliveryPremiumType { get; set; }
}

public class InternationalControlledExportDetail
{
    [JsonProperty("type")] public string? Type { get; set; }
}

public class InternationalTrafficInArmsRegulationsDetail
{
    [JsonProperty("licenseOrExemptionNumber")]
    [JsonConverter(typeof(StringLongConverter))]
    public long? LicenseOrExemptionNumber { get; set; }
}

public class PendingShipmentDetail
{
    [JsonProperty("pendingShipmentType")] public string? PendingShipmentType { get; set; }

    [JsonProperty("processingOptions")] public ProcessingOptions? ProcessingOptions { get; set; }

    [JsonProperty("recommendedDocumentSpecification")]
    public RecommendedDocumentSpecification? RecommendedDocumentSpecification { get; set; }

    [JsonProperty("emailLabelDetail")] public EmailLabelDetail? EmailLabelDetail { get; set; }

    [JsonProperty("documentReferences")] public List<DocumentReference>? DocumentReferences { get; set; }

    [JsonProperty("expirationTimeStamp")] public DateTimeOffset? ExpirationTimeStamp { get; set; }

    [JsonProperty("shipmentDryIceDetail")] public ShipmentDryIceDetail? ShipmentDryIceDetail { get; set; }
}

public class DocumentReference
{
    [JsonProperty("documentType")] public string? DocumentType { get; set; }

    [JsonProperty("customerReference")] public string? CustomerReference { get; set; }

    [JsonProperty("description")] public string? Description { get; set; }

    [JsonProperty("documentId")]
    [JsonConverter(typeof(StringLongConverter))]
    public long? DocumentId { get; set; }
}

public class EmailLabelDetail
{
    [JsonProperty("recipients")] public List<EmailLabelDetailRecipient>? Recipients { get; set; }

    [JsonProperty("message")] public string? Message { get; set; }
}

public class EmailLabelDetailRecipient
{
    [JsonProperty("emailAddress")] public string? EmailAddress { get; set; }

    [JsonProperty("optionsRequested")] public ProcessingOptions? OptionsRequested { get; set; }

    [JsonProperty("role")] public string? Role { get; set; }

    [JsonProperty("locale")] public Locale? Locale { get; set; }
}

public class Locale
{
    [JsonProperty("country")] public string? Country { get; set; }

    [JsonProperty("language")] public string? Language { get; set; }
}

public class ProcessingOptions
{
    [JsonProperty("options")] public List<string>? Options { get; set; }
}

public class RecommendedDocumentSpecification
{
    [JsonProperty("types")] public List<string>? Types { get; set; }
}

public class ShipmentDryIceDetail
{
    [JsonProperty("totalWeight")] public Weight? TotalWeight { get; set; }

    [JsonProperty("packageCount")] public long? PackageCount { get; set; }
}

public class ReturnShipmentDetail
{
    [JsonProperty("returnType")] public string? ReturnType { get; set; }
}

public class ShipmentCodDetail
{
    [JsonProperty("addTransportationChargesDetail")]
    public AddTransportationChargesDetail? AddTransportationChargesDetail { get; set; }

    [JsonProperty("codRecipient")] public CodRecipient? CodRecipient { get; set; }

    [JsonProperty("remitToName")] public string? RemitToName { get; set; }

    [JsonProperty("codCollectionType")] public string? CodCollectionType { get; set; }

    [JsonProperty("financialInstitutionContactAndAddress")]
    public TionContactAndAddress? FinancialInstitutionContactAndAddress { get; set; }

    [JsonProperty("returnReferenceIndicatorType")]
    public string? ReturnReferenceIndicatorType { get; set; }
}

public class AddTransportationChargesDetail
{
    [JsonProperty("rateType")] public string? RateType { get; set; }

    [JsonProperty("rateLevelType")] public string? RateLevelType { get; set; }

    [JsonProperty("chargeLevelType")] public string? ChargeLevelType { get; set; }

    [JsonProperty("chargeType")] public string? ChargeType { get; set; }
}

public class CodRecipient
{
    [JsonProperty("accountNumber")] public PickupOriginAccountNumber? AccountNumber { get; set; }
}

public class SmartPostInfoDetail
{
    [JsonProperty("ancillaryEndorsement")] public string? AncillaryEndorsement { get; set; }

    [JsonProperty("hubId")]
    [JsonConverter(typeof(StringLongConverter))]
    public long? HubId { get; set; }

    [JsonProperty("indicia")] public string? Indicia { get; set; }

    [JsonProperty("specialServices")] public string? SpecialServices { get; set; }
}