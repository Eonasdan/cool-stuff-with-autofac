namespace CoolStuff.Business.Models;

public class OrderSummary
{
    public Address? SenderAddress { get; set; }

    public Address? ReceiverAddress { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new();
}

public class OrderItem
{
    public decimal Height { get; set; }
    public decimal Width { get; set; }
    public decimal Length { get; set; }
    public decimal Weight { get; set; }
}

public class Address
{
    public string? City { get; set; }

    public string? Line1 { get; set; }

    public string? Line2 { get; set; }

    public string? Line3 { get; set; }

    public string? ZipCode { get; set; }

    public string? State { get; set; }
}