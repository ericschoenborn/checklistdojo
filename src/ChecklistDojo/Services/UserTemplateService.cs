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
        Task<(List<UserTemplate>, Error)> GetUserTemplates();
    }

    public class UserTemplateService : IUserTemplateService
    {
        private ILogger Log { get; }

        private IUserTemplateRepository UserTemplate { get; }

        public UserTemplateService(ILogger log, IUserTemplateRepository userTemplate)
        {
            Log = log.ForContext<UserTemplateService>();
            UserTemplate = userTemplate;
        }

        public async Task<(List<UserTemplate>, Error)> GetUserTemplates()
        {
            return (null, null);
        }

    }
}