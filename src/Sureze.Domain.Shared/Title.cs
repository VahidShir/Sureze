using System.ComponentModel.DataAnnotations;

namespace Sureze;

public enum Title
{
    [Display(Name = "")]
    NotSet,

    [Display(Name = "Baby of")]
    BabyOf,

    [Display(Name = "Cik")]
    Cik,

    [Display(Name = "Encik")]
    Encik,

    [Display(Name = "Doktor")]
    Doktor,

    [Display(Name = "Puan")]
    Puan,

    [Display(Name = "Haji")]
    Haji,

    [Display(Name = "Datin")]
    Datin,

    [Display(Name = "Datin Amar")]
    DatinAmar,

    [Display(Name = "Datin Dr")]
    DatinDr,

    [Display(Name = "Datin Paduka")]
    DatinPaduka,

    [Display(Name = "Datin Patinggi")]
    DatinPatinggi,

    [Display(Name = "Datin Professor")]
    DatinProfessor,

    [Display(Name = "Datin Professor Dr")]
    DatinProfessorDr,

    [Display(Name = "CikDatin Setia")]
    DatinSetia,

    [Display(Name = "Datin Sri")]
    DatinSri,

    [Display(Name = "Datin Sri Cempaka")]
    DatinSriCempaka,

    [Display(Name = "Datin Sri Dr")]
    DatinSriDr,

    [Display(Name = "Dato")]
    Dato,

    [Display(Name = "Dato Dr")]
    DatoDr,

    [Display(Name = "Dato Ir")]
    DatoIr,

    [Display(Name = "Dato Ir Dr")]
    DatoIrDr,

    [Display(Name = "Dato Paduka Dr")]
    DatoPadukaDr,

    [Display(Name = "Dato Professor Madya Dr")]
    DatoProfessorMadyaDr,

    [Display(Name = "Dato Senara Muda")]
    DatoSenaraMuda,

    [Display(Name = "Dato Seri")]
    DatoSeri,

    [Display(Name = "Dato Sri ")]
    DatoSri,

    [Display(Name = "Datu")]
    Datu,

    [Display(Name = "Datuk")]
    Datuk,

    [Display(Name = "Datuk Amar")]
    DatukAmar,

    [Display(Name = "Datuk Bentara Luar")]
    DatukBentaraLuar,

    [Display(Name = "Datuk Bentara Raja")]
    DatukBentaraRaja,

    [Display(Name = "Datuk Dr")]
    DatukDr,

    [Display(Name = "Datuk Ir")]
    DatukIr,

    [Display(Name = "Datuk Patinggi")]
    DatukPatinggi,

    [Display(Name = "Datuk Professor")]
    DatukProfessor,

    [Display(Name = "Datuk Professor Dr")]
    DatukProfessorDr,

    [Display(Name = "Datuk Setia")]
    DatukSetia,

    [Display(Name = "Datuk Setia Wangsa")]
    DatukSetiaWangsa,

    [Display(Name = "Datuk Sri")]
    DatukSri

    //...remaining items omitted
}