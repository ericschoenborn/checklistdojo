using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.PostgreSQL
{

    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }
        public DbSet<Checklist_Template_User> TodoItems { get; set; }

    }

    public class Checklist_Template_User
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Json { get; set; }
    }

}