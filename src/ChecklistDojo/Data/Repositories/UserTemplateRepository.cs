using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ChecklistDojo.Data.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ChecklistDojo.Data.Repositories
{
    public interface IUserTemplateRepository
    {
        Task<List<UserTemplate>> GetUserTemplates(string userId);
    }

    public class UserTemplateRepository : IUserTemplateRepository
    {
        private string connectionString;

        public UserTemplateRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        internal IDbConnection Connection
        {
            get { return new NpgsqlConnection(connectionString); }
        }

        public async Task<List<UserTemplate>> GetUserTemplates(string userId)
        {
            // TODO: Add logging

            if (userId == "error")
            {
                throw new Exception("This is a simulated error");
            }

            // Starting with returning hardcoded a user template since we don't currently have any scripts for setting up a PostgesSql container
            return
                new List<UserTemplate>
                {
                    new UserTemplate {
                        Id = "asdf",
                        UserId = userId,
                        Name = "A very neat list",
                        Json = "This is invalid json, sure hope we validate this in the frontend"
                    }
                };

            // TODO: Update query so it filters on user
            // using (IDbConnection dbConnection = Connection)
            // {
            //     dbConnection.Open();
            //     return dbConnection.Query<UserTemplate>("SELECT * FROM ChecklistDojo.ChecklistTemplateUser").ToList();

            // }
        }
    }
}