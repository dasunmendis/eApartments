using System.ComponentModel.DataAnnotations;

namespace GlobeFa.DAL.Enums
{
    public enum TextConversionTypeEnum : int
    {
        [Display(Name = "UpperCase")]
        UpperCase = 1,
        [Display(Name = "LowerCase")]
        LowerCase = 2,
        [Display(Name = "TitleCase")]
        TitleCase = 3
    }
    
}
