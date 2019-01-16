using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChecklistDojo.Services;

namespace ChecklistDojo.Controllers
{
    [Route("~/ChecklistTemplate")]
    public class UserTemplateController : Controller
    {
        private IUserTemplateService UserTemplateService { get; }
        public UserTemplateController(IUserTemplateService userTemplateService)
        {
            UserTemplateService = userTemplateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserTemplates()
        {
            var (userTemplate, error) = await UserTemplateService.GetUserTemplates().ConfigureAwait(false);
            return Json("{content}");
        }
    }
}