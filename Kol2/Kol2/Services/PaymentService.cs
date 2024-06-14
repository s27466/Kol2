using Kol2.Context;
using Kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Services;

public class PaymentService
{
    private readonly SubscriptionsDbContext _context;

    public PaymentService(SubscriptionsDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddPaymentAsync(int clientId, int subscriptionId, decimal amount)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client == null)
            throw new Exception("Client not found");

        var subscription = await _context.Subscriptions
            .Include(s => s.Payments)
            .Include(s => s.Discounts)
            .FirstOrDefaultAsync(s => s.IdSubscription == subscriptionId);
        if (subscription == null)
            throw new Exception("Subscription not found");

        if (subscription.EndDate.HasValue && subscription.EndDate.Value < DateTime.Now)
            throw new Exception("Subscription is not active");

        var nextPaymentDate = subscription.CreatedAt.AddMonths(subscription.RenewalPeriod);
        if (subscription.Payments.Any(p => p.PaymentDate >= nextPaymentDate))
            throw new Exception("Subscription already paid for this period");

        var discount = subscription.Discounts
            .Where(d => d.StartDate <= DateTime.Now && (d.EndDate == null || d.EndDate >= DateTime.Now))
            .OrderByDescending(d => d.Value)
            .FirstOrDefault();
        var finalAmount = discount != null ? amount - (amount * discount.Value / 100) : amount;

        if (finalAmount != subscription.Amount)
            throw new Exception("Invalid payment amount");

        var payment = new Payment
        {
            IdPayment = clientId,
            SubscriptionId = subscriptionId,
            Amount = finalAmount,
            PaymentDate = DateTime.Now
        };

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        return payment.IdPayment;
    }
}
