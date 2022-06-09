using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test2.Context;
using Test2.Service;

namespace Test2.Controllers
{
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var clients = await _clientService.FindAll();
            if (clients.Count == 0)
            {
                return NotFound();
            }
            return Ok(clients);
        }
    }
}