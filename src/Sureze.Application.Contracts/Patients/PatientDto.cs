using System;
using System.ComponentModel.DataAnnotations;

using Volo.Abp.Application.Dtos;

namespace Sureze;

public class PatientDto : EntityDto<Guid>
{
    public Title Title { get; set; }

    [MaxLength(50)]
    public string Suffix { get; set; }

    [Required]
    public string FirstName { get; set; }

    [MaxLength(200)]
    public string LastName { get; set; }

    //need to know business: is the type number or string?
    public string NationalIdNumber { get; set; }

    public AlternateIdType AlternateIdType { get; set; }

    //need to know business: is the type number or string?
    public string AlternateIdNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public Sex Sex { get; set; }

    [Required]
    public Race Race { get; set; }

    public Language Language { get; set; }

    public Ethnicity Ethnicity { get; set; }

    public EducationLevel EducationLevel { get; set; }

    public string Nationality { get; set; }

    [Required]
    public bool Citizen { get; set; }

    public Religion Religion { get; set; }

    public MaritalStatus MaritalStatus { get; set; }

    public string PatientCategory { get; set; }

    public string ProfilePictureUrl { get; set; }
}
