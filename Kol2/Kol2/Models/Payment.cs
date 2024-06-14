using System.ComponentModel.DataAnnotations;

namespace Kol2.Models;

public class Payment
{
    [Key]
    public int IdPayment { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public int SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
}

