using Kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kol2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly ClientService _clientService;

    public ClientController(ClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("{idClient}")]
    public async Task<IActionResult> GetClientWithSubscriptions(int idClient)
    {
        var client = await _clientService.GetClientWithSubscriptionsAsync(idClient);
        if (client == null)
            return NotFound();

        var result = new
        {
            client.FirstName,
            client.LastName,
            client.Email,
            client.Phone,
            Subscriptions = client.Subscriptions.Select(s => new
            {
                Id = s.IdSubscription,
                s.Name,
                TotalPaidAmount = s.Payments.Sum(p => p.Amount)
            }).ToList()
        };

        return Ok(result);
    }
}
