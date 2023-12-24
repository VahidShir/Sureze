using Sureze.Patients;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Sureze;

public class PatientsService :
    CrudAppService<
        Patient, //The patient entity
        PatientDto, //Used to show patients
        Guid, //Primary key of the patient entity
        PagedAndSortedAndFilteredResultRequestDto, //Used for paging/sorting/filtering
        CreateUpdatePatientDto>, //Used to create/update a patient
    IPatientsService //implement the IPatientsService
{
    public PatientsService(IRepository<Patient, Guid> _patientsRepository) : base(_patientsRepository)
    {
    }

    public override async Task<PagedResultDto<PatientDto>> GetListAsync(PagedAndSortedAndFilteredResultRequestDto input)
    {
        Check.NotNull(input, nameof(input));

        //Get the IQueryable<Book> from the repository
        var queryable = await Repository.GetQueryableAsync();

        PatientFilter filter = input.PatientFilter;

        Expression<Func<Patient, bool>> fullNamePredicate = x =>
                                x.FirstName.ToLower().Contains(filter.FullName.ToLower())
                                || x.LastName.ToLower().Contains(filter.FullName.ToLower());

        // apply filter
        var query = queryable
                .WhereIf(!filter.FullName.IsNullOrWhiteSpace(), fullNamePredicate)
                .WhereIf(filter.DateOfBirth is not null, x => x.DateOfBirth == filter.DateOfBirth)
                .WhereIf(filter.Sex is not null, x => x.Sex.ToString().Contains(filter.Sex, StringComparison.OrdinalIgnoreCase))
                .WhereIf(filter.Nationality is not null, x => x.Nationality.ToString().Contains(filter.Nationality, StringComparison.OrdinalIgnoreCase))
                .WhereIf(!filter.NationalIdNumber.IsNullOrWhiteSpace(), x => x.NationalIdNumber.Contains(filter.NationalIdNumber, StringComparison.OrdinalIgnoreCase));

        // apply sorting
        if (!input.Sorting.IsNullOrWhiteSpace())
        {
            query = query.OrderBy(input.Sorting);
        }

        // apply pagination
        query = query.Skip(input.SkipCount)
                .Take(input.MaxResultCount);

        //Execute the query and get a list
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //Convert the query result to a list of PatientDto objects
        var patientDtos = queryResult.Select(p => ObjectMapper.Map<Patient, PatientDto>(p)).ToList();

        //Get the total count with another query
        var totalCount = await Repository.GetCountAsync();

        return new PagedResultDto<PatientDto>(
            totalCount: totalCount,
            items: patientDtos
        );
    }
}