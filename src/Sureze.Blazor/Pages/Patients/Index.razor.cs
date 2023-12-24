using Blazorise;
using Blazorise.DataGrid;

using Microsoft.AspNetCore.Components;

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

    private DataGrid<PatientDto> DataGrid { get; set; }

    public IReadOnlyList<PatientDto> Patients { get; set; }

    private int PageSize { get; set; } = LimitedResultRequestDto.DefaultMaxResultCount;

    private int CurrentPage { get; set; }

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
            string searchValue = column.SearchValue?.ToString();

            if (column.SortField == nameof(PatientDto.FirstName))
            {
                CurrentFilter.FullName = searchValue;
            }
            if (column.SortField == nameof(PatientDto.DateOfBirth))
            {
                CurrentFilter.DateOfBirth = searchValue.IsNullOrWhiteSpace() ? null : DateTime.Parse(searchValue);
            }
            if (column.SortField == nameof(PatientDto.Sex))
            {
                CurrentFilter.Sex = searchValue;
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

    private void OnFilteredDataChanged(DataGridFilteredDataEventArgs<PatientDto> e)
    {
        var test = DataGrid;
    }
}