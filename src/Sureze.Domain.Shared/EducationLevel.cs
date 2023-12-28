using System.ComponentModel.DataAnnotations;

namespace Sureze;

public enum EducationLevel
{
    [Display(Name = "")]
    NotSet,

    [Display(Name = "No Information")]
    NoInformation,

    [Display(Name = "PhD")]
    PhD,

    [Display(Name = "Sarjana")]
    Sarjana,

    [Display(Name = "Ijazah")]
    Ijazah,

    [Display(Name = "Diploma")]
    Diploma,

    [Display(Name = "Sijil")]
    Sijil,

    [Display(Name = "STPM/Setaraf")]
    STPMSetaraf,

    [Display(Name = "SPM/SPVM/Setara")]
    SPpmSpvmSetara,

    [Display(Name = "SRP/PMR/Setaraf")]
    SrpPmrSetaraf,

    [Display(Name = "Sek.Ren/Setaraf")]
    SekRenSetaraf,

    [Display(Name = "T/Bersekolah")]
    TBersekolah,
}