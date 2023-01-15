using System;
using GlobeFa.DAL.Enums;

namespace GlobeFa.DAL.EntitiesDTO
{
    public partial class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string NIC { get; set; }
        public EmploymentTypeEnum? EmploymentType { get; set; }
        public string RoleTypeDes { get; set; }
        public string UserGroup { get; set; }
        public string MaritalStatus { get; set; }
        public bool? IsActive { get; set; }
        public string EmployeeNumber { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
