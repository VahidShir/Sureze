using System.ComponentModel.DataAnnotations;

namespace Sureze;

public enum AlternateIdType
{
    [Display(Name = "")]
    NotSet,

    [Display(Name = "MyKad")]
    MyKad,

    [Display(Name = "MyKid")]
    MyKid,

    [Display(Name = "Old I/C")]
    OldIc,

    [Display(Name = "Birth Certificate")]
    BirthCertificate,

    [Display(Name = "Police Id")]
    PoliceId,

    [Display(Name = "Army Id")]
    ArmyId,

    [Display(Name = "Passport")]
    Passport,

    [Display(Name = "Fathers I/C")]
    FathersIc,

    [Display(Name = "Mothers I/C")]
    MothersIc,

    [Display(Name = "GUID")]
    GUID,

    [Display(Name = "Others")]
    Others,

    [Display(Name = "Auto Generate")]
    AutoGenerate
}