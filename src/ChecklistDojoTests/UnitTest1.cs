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

namespace ChecklistDojoTests
{
    [Trait("Category", "Unit")]
    public class UnitTest1
    {
        public JObject json = (JObject)JsonConvert.DeserializeObject(File.ReadAllText("appsettings.Development.json"));
        [Fact]
        public void ConnectToDataBase_WhenGoodConnectionStringGiven()
        {
            var path = json.GetValue("DBInfo:ConnectionString").ToString();
            IDbConnection connection;
            Exception problem;
            try
            {
                connection = new NpgsqlConnection(path);
                connection.Open();
                problem = null;
            }
            catch(Exception ex)
            {
                connection = null;
                problem = ex;
            }
            Assert.Null(problem);
            Assert.NotNull(connection);
        }
        [Fact]
        public void FailConnectToDataBase_WhenBadConnectionStringGiven()
        {
            IDbConnection connection;
            Exception problem;
            try
            {
                connection = new NpgsqlConnection("Bad Connection String");
                connection.Open();
                problem = null;
            }
            catch (Exception ex)
            {
                connection = null;
                problem = ex;
            }
            Assert.NotNull(problem);
            Assert.Null(connection);
        }
        [Fact]
        public void RetrieveFromDatabase_WhenTableExists()
        {
            var path = json.GetValue("DBInfo:ConnectionString").ToString();
            var connection = new NpgsqlConnection(path);
            connection.Open();
            Exception problem;
            List<UserTemplate> userTemplates;
            try
            {
                userTemplates = connection.Query<UserTemplate>("SELECT * FROM ChecklistDojo.ChecklistTemplateUser").ToList();
                problem = null;
            }
            catch (Exception ex)
            {
                userTemplates = null;
                problem = ex;
            }
            Assert.Null(problem);
            Assert.NotNull(userTemplates);
        }
        [Fact]
        public void FailRetrieveFromDatabase_WhenTableNotExists()
        {
            var path = json.GetValue("DBInfo:ConnectionString").ToString();
            var connection= new NpgsqlConnection(path);
            connection.Open();
            Exception problem;
            List<UserTemplate> userTemplates;
            try
            {
                userTemplates = connection.Query<UserTemplate>("SELECT * FROM FAKE.TABLE").ToList();
                problem = null;
            }
            catch (Exception ex)
            {
                userTemplates = null;
                problem = ex;
            }
            Assert.NotNull(problem);
            Assert.Null(userTemplates);
        }
    }
}
