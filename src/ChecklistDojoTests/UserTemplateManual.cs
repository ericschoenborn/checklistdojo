using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Xunit;
using Dapper;
using Npgsql;
using ChecklistDojoTest.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Project.Test
{
    [Trait("Category", "Unit")]
    public class UserTemplateManual
    {
        public JObject json = (JObject)JsonConvert.DeserializeObject(File.ReadAllText("appsettings.Development.json"));

        [Fact]
        public void RetrieveFromDatabase_WhenTableExists()
        {
            var path = json.GetValue("DBInfo:ConnectionString");
            var connection = new NpgsqlConnection(path);
            connection.Open();
            List<UserTemplate> userTemplates = connection.Query<UserTemplate>("SELECT * FROM ChecklistDojo.ChecklistTemplateUser").ToList();

            Assert.True(userTemplates.Count>0);
            Assert.NotNull(userTemplates[0].ID);
            Assert.NotNull(userTemplates[0].UserID);
            Assert.NotNull(userTemplates[0].Name);
            Assert.NotNull(userTemplates[0].Json);
        }
        [Fact]
        public void FailRetrieveFromDatabase_WhenTableNotExists()
        {
            var path = json.GetValue("DBInfo:ConnectionString");
            var connection= new NpgsqlConnection(path);
            connection.Open();
            List<UserTemplate> userTemplates;
            try
            {
                userTemplates = connection.Query<UserTemplate>("SELECT * FROM FAKE.TABLE").ToList();
            }
            catch
            {
                userTemplates = null;
            }
            

            Assert.Null(userTemplates);
        }
    }
}
