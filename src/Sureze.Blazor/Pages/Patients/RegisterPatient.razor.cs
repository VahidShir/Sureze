using Blazorise;

using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Sureze.Blazor.Pages.Patients;

public partial class RegisterPatient : SurezeComponentBase
{

    public Patient Patient { get; set; }

    public void OnGet()
    {
    }

    [Inject] IMessageService MessageService { get; set; }

    Validations ValidationsRef { get; set; }

    async Task OnSaveClicked()
    {
        if (await ValidationsRef.ValidateAll())
        {
            await MessageService.Info("Thank you for filling the form.");

            await ValidationsRef.ClearAll();
        }
    }
}