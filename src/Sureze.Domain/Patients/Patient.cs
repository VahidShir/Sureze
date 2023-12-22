using System;

using Volo.Abp.Domain.Entities;

namespace Sureze.Patients;

public class Patient : AggregateRoot<Guid>
{
    protected Patient()
    {

    }

    public Patient(Guid id , string firstName, Race race, bool citizen) : base(id)
    {
        FirstName = firstName;
        Race = race;
        Citizen = citizen;
    }

    public Title Title { get; set; }

    public string Suffix { get; set; }

    //[required]
    public string FirstName { get; set; }

    public string LastName { get; set; }

    //need to know business: is the type number or string?
    public string NationalIdNumber { get; set; }

    public AlternateIdType AlternateIdType { get; set; }

    //need to know business: is the type number or string?
    public string AlternateIdNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public Sex Sex { get; set; }

    public Race Race { get; set; }

    public Language Language { get; set; }

    public Ethnicity Ethnicity { get; set; }

    public EducationLevel EducationLevel { get; set; }

    public Country Nationality { get; set; }

    public bool Citizen { get; set; }

    public Religion Religion { get; set; }

    public MaritalStatus MaritalStatus { get; set; }

    public string PatientCategory { get; set; }

    public string ProfilePictureUrl { get; set; }
}