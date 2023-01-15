using GlobeFa.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GlobeFa.DAL.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }
        public string Title { get; set; }
        //public string Address1 { get; set; }
        //public string Address2 { get; set; }
        //public string City { get; set; }
        //public string Country { get; set; }
        //public string PostalCode { get; set; }
        //public string Email { get; set; }
        //public string ContactNumber { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string NICNumber { get; set; }
        public EmploymentTypeEnum? EmploymentType { get; set; }
        public string RoleTypeDes { get; set; }
        public string UserGroup { get; set; }
        public string MaritalStatus { get; set; }
        public bool? IsActive { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        // Navigation Properties
        public virtual ICollection<Contact> Contacts  { get; set; }
    }
}
