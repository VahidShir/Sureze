using System.ComponentModel.DataAnnotations;

namespace Sureze;

public enum Religion
{
    [Display(Name = "")]
    NotSet,

    [Display(Name = "MAKLUMAT TIADA")]
    MAKLUMAT_TIADA,

    [Display(Name = "ISLAM")]
    ISLAM,

    [Display(Name = "KRISTIAN")]
    KRISTIAN,

    [Display(Name = "BUDDHA")]
    BUDDHA,

    [Display(Name = "HINDU")]
    HINDU,

    [Display(Name = "SIKLISM")]
    SIKLISM,

    [Display(Name = "TIADA UGAMA")]
    TIADA_UGAMA,

    [Display(Name = "TAO")]
    TAO,

    [Display(Name = "KONFUSIANISME")]
    KONFUSIANISME,

    [Display(Name = "BAHAI")]
    BAHAI,

    [Display(Name = "PUAK/SUKU")]
    PUAK_SUKU,

    [Display(Name = "LAIN UGAMA")]
    LAIN_UGAMA
}