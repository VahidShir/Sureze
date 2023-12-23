using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Sureze;

public class PatientsService :
    CrudAppService<
        Patient, //The patient entity
        PatientDto, //Used to show patients
        Guid, //Primary key of the patient entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdatePatientDto>, //Used to create/update a patient
    IPatientsService //implement the IPatientsService
{
    //private readonly IRepository<Patient, Guid> _patientsRepository;

    public PatientsService(IRepository<Patient, Guid> _patientsRepository) : base(_patientsRepository)
    {
        //_patientsRepository = _patientsRepository ?? throw new ArgumentNullException();
    }
}