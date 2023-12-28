using Blazorise;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sureze.Blazor.Pages.Patients;

public abstract class PatientBasePage : SurezeComponentBase
{
    protected bool IsFormDisabled;
    protected string SaveButtonTitle = "Save";
    protected Validations Validations { get; set; }
    protected abstract string FormTitle { get; set; }
    protected PatientDto Patient { get; set; } = new();

    [Inject] public IPatientsService PatientsService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IFileUploader FileUploader { get; set; }

    [Inject] public IWebHostEnvironment WebHostEnvironment { get; set; }

    protected abstract Task OnSaveButtonClicked();
}