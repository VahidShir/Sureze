using Microsoft.AspNetCore.Components;

using System;
using System.Threading.Tasks;

namespace Sureze.Blazor.Pages.Patients;

public partial class RegisterPatient : PatientBasePage
{
    private _PatientForm _form;
    protected override string FormTitle { get; set; } = "Register Patient";

    protected override async Task OnSaveButtonClicked()
    {
        if (await _form.Validations.ValidateAll())
        {
            var model = ObjectMapper.Map<PatientDto, CreateUpdatePatientDto>(Patient);

            if (Patient.ProfilePictureUrl.IsNullOrWhiteSpace())
            {
                Patient.ProfilePictureUrl = $"{WebHostEnvironment.WebRootPath}\\images\\default_profile_man.png";
            }

            //to register a new patient
            await PatientsService.CreateAsync(model);
            await Notify.Success("Patient was created successfully");
            NavigationManager.NavigateTo("/Patients");
        }
    }
}