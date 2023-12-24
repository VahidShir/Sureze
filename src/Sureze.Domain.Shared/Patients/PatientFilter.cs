using System;

namespace Sureze.Patients;

/// <summary>
/// Used to get patients from db using this filter 
/// </summary>
public class PatientFilter
{
    public string FullName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Sex { get; set; }
    public string? NationalIdNumber { get; set; }
    public string Nationality { get; set; }
}