namespace JetSwagStore.Models;

public class Order
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string CustomerEmail { get; set; } = "";
    public string ExternalPaymentId { get; set; } = "";

    public DateTime PurchasedAt { get; set; }
        = DateTime.UtcNow;

    public string Status { get; set; }
        = OrderStatuses.Submitted;

    public string ShippingStreet { get; set; } = "";
    public string ShippingCity { get; set; } = "";
    public string ShippingStateOrProvince { get; set; } = "";
    public string ShippingPostalCode { get; set; } = "";
    public string ShippingCountry { get; set; } = "";

    public ICollection<OrderItem> Items { get; set; }
        = new List<OrderItem>();
}

public static class OrderStatuses
{
    public const string Submitted = nameof(Submitted);
    public const string Processing = nameof(Processing);
    public const string Shipped = nameof(Shipped);
    public const string Delivered = nameof(Delivered);
    public const string Canceled = nameof(Canceled);
}