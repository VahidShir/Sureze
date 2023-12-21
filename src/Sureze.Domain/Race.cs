using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sureze;
public enum Race
{
    [Display(Name = "MALAY")]
    Malay,

    [Display(Name = "CINA")]
    Cina,

    [Display(Name = "INDIAN")]
    Indian,

    [Display(Name = "PRIBUMI SABAH LAIN")]
    PribumiSabahLain,

    [Display(Name = "BAJAU")]
    Bajau,

    [Display(Name = "KADAZAN")]
    Kadazan,

    [Display(Name = "MURUT")]
    Murut,

    [Display(Name = "MELANAU")]
    Melanau,

    [Display(Name = "PRIBUMI SARAWAK LAIN")]
    PribumiSarawakLain,

    [Display(Name = "IBAN")]
    Iban,

    [Display(Name = "BIDAYUH")]
    Bidayuh,

    [Display(Name = "ORANG ASLI SEMENANJUNG")]
    OrangAsliSemenanjung

    //...remaining items omitted
}
