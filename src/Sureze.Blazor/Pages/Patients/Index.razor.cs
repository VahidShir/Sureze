using Microsoft.AspNetCore.Components;

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using Volo.Abp.Application.Dtos;

namespace Sureze.Blazor.Pages.Patients;

public partial class Index : SurezeComponentBase
{
    [Inject]
    public IPatientsService PatientsService { get; set; }

    public IReadOnlyList<PatientDto> Patients { get; set; }

    public Index()
    {

    }

    protected override async Task OnInitializedAsync()
    {
        base.OnInitialized();

        PagedResultDto<PatientDto> result = await PatientsService.GetListAsync(new() { MaxResultCount = 50 });

        Patients = result.Items;
    }
}