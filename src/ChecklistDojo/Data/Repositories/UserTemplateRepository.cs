using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ChecklistDojo.Data.Models;

namespace ChecklistDojo.Data.Repositories
{
    public interface IUserTemplateRepository
    {
        Task<List<UserTemplate>> GetUserTemplates();
    }

    public class UserTemplateRepository : IUserTemplateRepository
    {
        public UserTemplateRepository()
        {

        }
        public async Task<List<UserTemplate>> GetUserTemplates()
        {
            return new List<UserTemplate>{};
        }
    }
}