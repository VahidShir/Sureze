using System.ComponentModel.DataAnnotations;

namespace Sureze;

public enum Language
{
    [Display(Name = "English")]
    English,
    [Display(Name = "Malay")]
    Malay,
    [Display(Name = "Tamil")]
    Tamil,
    [Display(Name = "Mandalin")]
    Mandalin,
    [Display(Name = "Thailand")]
    Thailand
}