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

        [HttpGet("/api/v1/Templates/{userId}")]
        public async Task<IActionResult> GetUserTemplates(string userId)
        {
            // TODO: Add logging
            var (userTemplate, error) = await UserTemplateService.GetUserTemplates(userId).ConfigureAwait(false);

            if (error != null)
            {
                return StatusCode(500, error);
            }
            return Json(userTemplate);
        }
    }
}