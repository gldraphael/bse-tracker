using System.Threading.Tasks;
using BSETracker.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace BSETracker.Web.Controllers
{
    public class TempController : Controller
    {
        [HttpGet("/api")]
        public async Task<IActionResult> Index([FromServices]BseClient bse) 
            => Ok(await bse.GetAnnouncements());
    }
}
