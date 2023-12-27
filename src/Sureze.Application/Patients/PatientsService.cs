using Sureze.Extensions;
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

        // normalize input
        NormalizeInputFilter(filter);

        Expression<Func<Patient, bool>> fullNamePredicate = x => (x.FirstName + " " + x.LastName).ToLower().Contains(filter.FullName);

        // apply filter
        var query = queryable
                .WhereIf(!filter.FullName.IsNullOrWhiteSpace(), fullNamePredicate)
                .WhereIf(filter.DateOfBirth is not null, x => x.DateOfBirth == filter.DateOfBirth)
                .WhereIf(!filter.Sex.IsNullOrWhiteSpace(), x => SearchEnum<Sex>(filter.Nationality).Any(y => x.Sex == y))
                .WhereIf(!filter.Nationality.IsNullOrWhiteSpace(), x => SearchEnum<Country>(filter.Nationality).Any(y => x.Nationality == y))
                .WhereIf(!filter.NationalIdNumber.IsNullOrWhiteSpace(), x => x.NationalIdNumber.ToLower().Contains(filter.NationalIdNumber));

        //Get the total count
        var totalCount = query.Count();

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

        return new PagedResultDto<PatientDto>(
            totalCount: totalCount,
            items: patientDtos
        );
    }

    private static void NormalizeInputFilter(PatientFilter filter)
    {
        filter.FullName = filter.FullName?.ToLower();
        filter.Sex = filter.Sex?.ToLower();
        filter.NationalIdNumber = filter.NationalIdNumber?.ToLower();
        filter.Nationality = filter.Nationality?.ToLower();
    }

    private static List<T> SearchEnum<T>(string searchValue) where T : struct, Enum
    {
        var result = Enum.GetValues<T>().ToList().FindAll(c => c.GetDisplayName().ToLower().Contains(searchValue.ToLower()));
        return result;
    }
}