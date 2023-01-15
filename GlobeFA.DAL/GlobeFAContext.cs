using System.Data.Entity;
using GlobeFa.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GlobeFa.DAL
{
    public class GlobeFAContext : IdentityDbContext<ApplicationUser>
    {
        public GlobeFAContext()
            : base("GlobeFAConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
       
    }
}
