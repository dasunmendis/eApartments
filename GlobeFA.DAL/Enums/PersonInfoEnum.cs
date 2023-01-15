using System.ComponentModel.DataAnnotations;

namespace GlobeFa.DAL.Enums
{
    public enum TitleEnum : int
    {
        [Display(Name = "Single")]
        Single = 1,
        [Display(Name = "Married")]
        Married = 2,
        [Display(Name = "Divorced")]
        Divorced = 3
    }

    public enum MaritalStatusEnum : int
    {
        [Display(Name = "Single")]
        Single = 1,
        [Display(Name = "Married")]
        Married = 2,
        [Display(Name = "Divorced")]
        Divorced = 3
    }

}
