using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ChecklistDojo.Data.Models;
using ChecklistDojo.Data.Repositories;
using Serilog;

namespace ChecklistDojo.Services
{
    public interface IUserTemplateService
    {
        Task<(List<UserTemplate>, Exception)> GetUserTemplates();
    }

    public class UserTemplateService : IUserTemplateService
    {
        private ILogger Log { get; }

        private IUserTemplateRepository UserTemplateRepo { get; }

        public UserTemplateService(ILogger log, IUserTemplateRepository userTemplateRepo)
        {
            Log = Log.ForContext<UserTemplateService>();
            UserTemplateRepo = userTemplateRepo;
        }

        public async Task<(List<UserTemplate>, Exception)> GetUserTemplates()
        {
            List<UserTemplate> userTemplates;
            try
            {
                userTemplates = await UserTemplateRepo.GetUserTemplates().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to retrieve user templates");

                return (null, ex);
            }
            return (userTemplates, null);
        }

    }
}