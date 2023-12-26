using Blazorise;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;

using Sureze.Migrations;

using System;
using System.Linq;
using System.Threading.Tasks;

using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace Sureze.Blazor.Pages.Patients;

public partial class RegisterAndEditPatient : SurezeComponentBase
{

    public PatientDto Patient { get; set; } = new();

    private bool _isEditingMode = false;
    private bool _isEditable = false;
    private Validations _validations;

    [Parameter]
    public Guid? PatientId { get; set; }

    [Inject]
    public IPatientsService PatientsService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IFileUploader FileUploader { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (PatientId is not null)
        {
            Patient = await PatientsService.GetAsync(PatientId.Value);

            _isEditingMode = true;
        }
        else
        {
            _isEditingMode = false;
        }
    }

    [Inject] IMessageService MessageService { get; set; }
    [Inject] IWebHostEnvironment WebHostEnvironment { get; set; }

    private async Task OnProfileUploadChanged(FileChangedEventArgs e)
    {
        try
        {
            var file = e.Files.SingleOrDefault();

            if (file is null)
                return;

            string path = await FileUploader.UploadAsync(file, Patient.Id.ToString());

            Patient.ProfilePictureUrl = path;

            StateHasChanged();
        }
        catch (Exception)
        {
            //alert user
        }
    }

    private async Task OnSaveEditClicked()
    {
        if (await _validations.ValidateAll())
        {
            
            var model = ObjectMapper.Map<PatientDto, CreateUpdatePatientDto>(Patient);

            if (Patient.ProfilePictureUrl.IsNullOrWhiteSpace())
            {
                Patient.ProfilePictureUrl = $"{WebHostEnvironment.WebRootPath}\\images\\profiles\\images\\default_profile_man.png";
            }

            if (!_isEditingMode)
            {
                //to register a new patient
                await PatientsService.CreateAsync(model);

                //alert user
            }
            else
            {
                //to register a new patient
                await PatientsService.UpdateAsync(Patient.Id, model);
            }
        }

    }

    private void ValidateImageUploader(ValidatorEventArgs e)
    {
        e.ErrorText = null;
        e.Status = ValidationStatus.Success;
    }
}