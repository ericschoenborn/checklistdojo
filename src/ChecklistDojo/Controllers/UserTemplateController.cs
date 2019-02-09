using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChecklistDojo.Services;

namespace ChecklistDojo.Controllers
{
    [Route("/api/v1/Templates")]
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

            if (error != null)
            {
                return Json(error);
            }
            return Json(userTemplate);
        }
    }
}