using System;

using Volo.Abp.Application.Services;

namespace Sureze;

public interface IPatientsService :
        ICrudAppService<
        PatientDto, //Used to show patients
        Guid, //Primary key of the patient entity
        PagedAndSortedAndFilteredResultRequestDto, //Used for paging/sorting
        CreateUpdatePatientDto> //Used to create/update a patient
{
}