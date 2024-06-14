using Kol2.Models;

namespace Kol2.Services;

public interface IClientService
{
    Task<Client> GetClientWithSubscriptionsAsync(int clientId);
}