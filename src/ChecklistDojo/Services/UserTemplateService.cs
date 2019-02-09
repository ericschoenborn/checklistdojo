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
        Task<(List<UserTemplate>, Error)> GetUserTemplates(string userId);
    }

    public class UserTemplateService : IUserTemplateService
    {
        private ILogger Log { get; }

        private IUserTemplateRepository UserTemplateRepo { get; }

        public UserTemplateService(ILogger log, IUserTemplateRepository userTemplateRepo)
        {
            Log = log.ForContext<UserTemplateService>();
            UserTemplateRepo = userTemplateRepo;
        }

        public async Task<(List<UserTemplate>, Error)> GetUserTemplates(string userId)
        {
            // TODO: Add logging
            List<UserTemplate> userTemplates;
            try
            {
                userTemplates = await UserTemplateRepo.GetUserTemplates(userId).ConfigureAwait(false);
                return (userTemplates, null);
            }
            catch (Exception ex)
            {
                var error = new Error
                {
                    Exception = ex,
                    Message = $"Failed to pull user templates for user with id {userId}",
                    ErrorCode = ErrorCode.ServerError
                };

                return (null, error);
            }
        }

    }
}