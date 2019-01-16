using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ChecklistDojo.Data.Models;

namespace ChecklistDojo.Services
{
    public interface IUserTemplateService
    {
        Task<(List<UserTemplate>, string)> GetUserTemplates();
    }

    public class UserTemplateService : IUserTemplateService
    {
        public UserTemplateService()
        {

        }

        public async Task<(List<UserTemplate>, string)> GetUserTemplates()
        {
            return (null, "error");
        }

    }
}