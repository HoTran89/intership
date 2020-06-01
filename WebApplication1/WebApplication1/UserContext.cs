using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=SchoolDBConnectionString")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
