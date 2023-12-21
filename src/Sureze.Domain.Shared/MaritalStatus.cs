using System.ComponentModel.DataAnnotations;

namespace Sureze;

public enum MaritalStatus
{
    [Display(Name = "Single")]
    Single,

    [Display(Name = "Married")]
    Married,

    [Display(Name = "Widowed")]
    Widowed,

    [Display(Name = "Divorced")]
    Divorced,

    [Display(Name = "Others")]
    Others
}