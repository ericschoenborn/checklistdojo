using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChecklistDojo.Controllers
{
    [Route("~/ChecklistTemplate")]
    public class UserTemplateController : Controller
    {
        public UserTemplateController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetUserTemplates()
        {
            return Json("{content}");
        }
    }
}