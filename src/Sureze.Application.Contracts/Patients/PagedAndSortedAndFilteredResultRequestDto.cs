using Sureze.Patients;

using Volo.Abp.Application.Dtos;

namespace Sureze;

public class PagedAndSortedAndFilteredResultRequestDto : PagedAndSortedResultRequestDto
{
    public PatientFilter PatientFilter { get; set; }
}