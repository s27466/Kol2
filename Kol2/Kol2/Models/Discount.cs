using System.ComponentModel.DataAnnotations;

namespace Kol2.Models;

public class Discount
{
    [Key]
    public int IdDiscount { get; set; }
    public int SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }
    public int Value { get; set; } // percentage
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

