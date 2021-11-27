using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante.Clientes.API.Controllers
{
    public class InvoiceController : Controller
    {
        
        [HttpGet("InvoicesHistory"), Authorize]
        public async Task<IActionResult> GetInvoicesHistory(CancellationToken cancellationToken = default)
        {
            return Ok();
        }

        private int GetLoggedUserId()
        {
            var userId = User.Claims.First(c => c.Type == "id").Value;
            return int.Parse(userId);
        }
    }
}
