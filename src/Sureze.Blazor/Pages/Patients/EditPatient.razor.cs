using Microsoft.AspNetCore.Components;

using System;
using System.Threading.Tasks;

namespace Sureze.Blazor.Pages.Patients;

public partial class EditPatient : PatientBasePage
{
    private _PatientForm _form;
    [Parameter] public Guid? PatientId { get; set; }

    protected override string FormTitle { get; set; } = "Patient Details";

    protected override async Task OnInitializedAsync()
    {
        Patient = await PatientsService.GetAsync(PatientId.Value);

        ToggleFormDisable(true);
    }

    protected override async Task OnSaveButtonClicked()
    {
        if (IsFormDisabled)
        {
            ToggleFormDisable(false);

            StateHasChanged();

            return;
        }

        if (await _form.Validations.ValidateAll())
        {
            var model = ObjectMapper.Map<PatientDto, CreateUpdatePatientDto>(Patient);

            if (Patient.ProfilePictureUrl.IsNullOrWhiteSpace())
            {
                Patient.ProfilePictureUrl = $"{WebHostEnvironment.WebRootPath}\\images\\default_profile_man.png";
            }

            await PatientsService.UpdateAsync(Patient.Id, model);

            await Notify.Success("Patient was edited successfully");

            ToggleFormDisable(true);
        }
    }

    private void ToggleFormDisable(bool _isDisable)
    {
        IsFormDisabled = _isDisable;
        SaveButtonTitle = _isDisable ? "Edit" : "Update";
    }
}