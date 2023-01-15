using System.ComponentModel.DataAnnotations;

namespace GlobeFa.DAL.Enums
{
    public enum EmploymentTypeEnum : int
    {
        [Display(Name = "Permanent")]
        Permanent = 1,
        [Display(Name = "Probation")]
        Probation = 2,
        [Display(Name = "Trainee")]
        Trainee = 3
    }

    public enum UserRoleTypeEnum : int
    {
        [Display(Name = "Admin")]
        Admin = 1,
        [Display(Name = "Accountant")]
        Accountant = 2,
        [Display(Name = "HR")]
        HumanResource = 3,
        [Display(Name = "User")]
        User = 4
    }
}
