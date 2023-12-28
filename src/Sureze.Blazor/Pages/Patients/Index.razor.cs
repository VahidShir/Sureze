using Blazorise;
using Blazorise.DataGrid;

using Microsoft.AspNetCore.Components;

using Polly;

using Sureze.Patients;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Volo.Abp.Application.Dtos;

namespace Sureze.Blazor.Pages.Patients;

public partial class Index : SurezeComponentBase
{
    [Inject]
    public IPatientsService PatientsService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    private DataGrid<PatientDto> _dataGrid;

    public IReadOnlyList<PatientDto> Patients { get; set; }

    private int PageSize { get; set; } = LimitedResultRequestDto.DefaultMaxResultCount;

    private int CurrentPage { get; set; }

    private string _globalPatientNameFilterValue;

    private List<object> SexItems = Enum.GetValues<Sex>().Select(x => (object)x).ToList();
    private bool AdvancedSearch { get; set; }

    private string CurrentSorting { get; set; }

    private PatientFilter CurrentFilter { get; set; } = new PatientFilter();

    private int TotalCount { get; set; }

    public Index()
    {

    }

    protected override async Task OnInitializedAsync()
    {
        base.OnInitialized();

        await GetPatientsAsync();
    }

    private async Task GetPatientsAsync()
    {
        var result = await PatientsService.GetListAsync(
            new PagedAndSortedAndFilteredResultRequestDto()
            {

                MaxResultCount = PageSize,
                SkipCount = CurrentPage * PageSize,

                Sorting = CurrentSorting,
                PatientFilter = CurrentFilter,
            }
        );

        Patients = result.Items;
        TotalCount = (int)result.TotalCount;
    }

    private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<PatientDto> e)
    {
        CurrentSorting = e.Columns
            .Where(c => c.SortDirection != SortDirection.Default)
            .Select(c => c.SortField + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
            .JoinAsString(",");

        foreach (var column in e.Columns)
        {
            string searchValue = column.SearchValue?.ToString().Trim();

            if (column.SortField == nameof(PatientDto.FirstName))
            {
                if (searchValue is null)
                {
                    CurrentFilter.FullName = _globalPatientNameFilterValue;
                }
                else
                {
                    CurrentFilter.FullName = searchValue;
                }
            }
            if (column.SortField == nameof(PatientDto.DateOfBirth))
            {
                CurrentFilter.DateOfBirth = searchValue.IsNullOrWhiteSpace() ? null : DateTime.Parse(searchValue);
            }
            if (column.SortField == nameof(PatientDto.Sex))
            {

                bool result = Enum.TryParse<Sex>(searchValue, ignoreCase: true, out var searchedSex);

                if (result && searchedSex != Sex.NotSet)
                {
                    CurrentFilter.Sex = searchedSex;
                }
                else
                {
                    CurrentFilter.Sex = null;
                }
            }
            if (column.SortField == nameof(PatientDto.NationalIdNumber))
            {
                CurrentFilter.NationalIdNumber = searchValue;
            }
            if (column.SortField == nameof(PatientDto.Nationality))
            {
                CurrentFilter.Nationality = searchValue;
            }
        }

        CurrentPage = e.Page - 1;

        await GetPatientsAsync();

        await InvokeAsync(StateHasChanged);
    }

    private Task OnCustomFilterValueChanged(string e)
    {
        _globalPatientNameFilterValue = e;
        return _dataGrid.Reload();
    }

    private bool OnCustomFilter(PatientDto model)
    {
        // We want to accept empty value as valid or otherwise
        // datagrid will not show anything.
        if (_globalPatientNameFilterValue.IsNullOrWhiteSpace())
            return true;

        return model.FullName?.Contains(_globalPatientNameFilterValue, StringComparison.OrdinalIgnoreCase) == true;
    }

    private void OnViewDetailsClicked(PatientDto patient)
    {
        NavigationManager.NavigateTo($"/EditPatient/{patient.Id}");
    }
}