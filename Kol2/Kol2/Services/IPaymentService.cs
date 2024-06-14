namespace Kol2.Services;

public interface IPaymentService
{
    Task<int> AddPaymentAsync(int clientId, int subscriptionId, decimal amount);
}