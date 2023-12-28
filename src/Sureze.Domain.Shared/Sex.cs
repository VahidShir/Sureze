using System.ComponentModel.DataAnnotations;

namespace Sureze;

public enum Sex
{
    [Display(Name = "")]
    NotSet,
    [Display(Name = "Female")]
    Female,
    [Display(Name = "Male")]
    Male,
    [Display(Name = "Others")]
    Others,
    [Display(Name = "Unknown")]
    Unknown
}