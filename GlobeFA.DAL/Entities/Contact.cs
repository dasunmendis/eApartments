using System;

namespace GlobeFa.DAL.Entities
{
    public partial class Contact
    {
        //public Contact()
        //{
        //    this.Employees = new HashSet<Employee>();
        //}

        public int Id { get; set; }
        public string ContactMobile { get; set; }
        public string ContactHome { get; set; }
        public string ContactCountryCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? PostalCode { get; set; }
        public string EmailPersonal { get; set; }
        public string EmailWork { get; set; }
        public int? CreatedById { get; set; }
        public int? CreatedByRoleTypeId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public int EmployeeId { get; set; }

        // Navigation Properties
        public virtual Employee Employee { get; set; }
    }
}
