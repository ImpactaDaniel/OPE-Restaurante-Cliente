using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Restaurante.Clientes.API.Controllers
{
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpGet("ItWorks")]
        public IActionResult Index()
        {
            return Ok("ItWorks");
        }
    }
}
