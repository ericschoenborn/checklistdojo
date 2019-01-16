using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using Npgsql;
using ClientApp.Models;
using Microsoft.Extensions.Configuration;

namespace ClientApp.Repository
{
    public class UserTemplateRepository : IRepository<UserTemplate>
    {
        private string connectionString;
        public UserTemplateRepository(IConfiguration configuration)
        {
            connectionString = configuration.connection;
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }
        public void Add(UserTemplate item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO ChecklistDojo.ChecklistTemplateUser (UserID, Name, Json) VALUES (@UserID,@Name,@Json)", item);
            }
        }
        public IEnumerable<UserTemplate> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<UserTemplate>("SELECT * FROM ChecklistDojo.ChecklistTemplateUser");
            }
        }
        public UserTemplate FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<UserTemplate>("SELECT * FROM ChecklistDojo.ChecklistTemplateUser WHERE id =@id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM ChecklistDojo.ChecklistTemplateUser Where id=@Id", new { id = id });
            }
        }
        public void Update(UserTemplate item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE checklistDojo.ChecklistTemplateUser Set UserID = @UserID, Name = @Name, Json = @Json WHERE id = @Id", item);
            }
        }
    }
}