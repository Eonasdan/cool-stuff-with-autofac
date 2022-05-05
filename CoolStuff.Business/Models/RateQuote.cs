namespace CoolStuff.Business.Models;

public class RateQuote
{
    public string Shipper { get; set; } = "FedEx";

    public string? SendingZip { get; set; }

    public string? ReceiverZip { get; set; }

    public int Weight { get; set; }
}