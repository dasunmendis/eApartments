using System.ComponentModel.DataAnnotations.Schema;
using GlobeFa.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GlobeFa.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int? EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
