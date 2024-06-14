using Kol2.Context;
using Kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Services;

public class ClientService
{
    private readonly SubscriptionsDbContext _context;

    public ClientService(SubscriptionsDbContext context)
    {
        _context = context;
    }

    public async Task<Client> GetClientWithSubscriptionsAsync(int clientId)
    {
        return await _context.Clients
            .Include(c => c.Subscriptions)
            .ThenInclude(s => s.Payments)
            .FirstOrDefaultAsync(c => c.IdClient == clientId);
    }
}
