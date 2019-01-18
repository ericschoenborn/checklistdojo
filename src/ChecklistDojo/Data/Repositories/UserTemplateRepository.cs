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
        Task<List<UserTemplate>> GetUserTemplates();
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

        public async Task<List<UserTemplate>> GetUserTemplates()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<UserTemplate>("SELECT * FROM ChecklistDojo.ChecklistTemplateUser").ToList();

            }
        }
    }
}