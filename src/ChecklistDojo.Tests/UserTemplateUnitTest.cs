using Xunit;
using ChecklistDojo.Data.Repositories;
using Microsoft.Extensions.Configuration;
using ChecklistDojo.Data.Models;

namespace ChecklistDojo.Tests
{
    [Trait("Category", "Unit")]
    public class UserTemplateUnitTest
    {
        [Fact]
        public void GetUserTemplate()
        {
            var config = new ConfigurationBuilder()
                 .AddJsonFile("appsetting.json")
                 .Build();

            var userTemplates = new UserTemplateRepository(config).GetUserTemplates();

            Assert.Null(userTemplates.Exception);
            Assert.True(userTemplates.Result.Count > 0);
            Assert.NotNull(userTemplates.Result[0].Id);
            Assert.NotNull(userTemplates.Result[0].Json);
            Assert.NotNull(userTemplates.Result[0].Name);
            Assert.NotNull(userTemplates.Result[0].UserId);
        }
    }
}
