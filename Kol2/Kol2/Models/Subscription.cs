using System.ComponentModel.DataAnnotations;

namespace Kol2.Models;

public class Subscription
{
    [Key]
    public int IdSubscription { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public int RenewalPeriod { get; set; } // in months
    public DateTime CreatedAt { get; set; }
    public DateTime? EndDate { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<Discount> Discounts { get; set; }
}

