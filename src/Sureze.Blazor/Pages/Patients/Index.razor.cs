using Blazorise;
using Blazorise.DataGrid;

using Microsoft.AspNetCore.Components;

using NUglify.Helpers;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
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

    private string CurrentFilter { get; set; }

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
            new()
            {
                
                MaxResultCount = PageSize,
                SkipCount = CurrentPage * PageSize,
                Sorting = CurrentSorting
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

        //CurrentFilter = e.Columns
        //    .Where(c => string.IsNullOrWhiteSpace(c.SearchValue?.ToString()) )
        //    .Select(c =>  $"{c.SortField} == " )
        //    .JoinAsString(",");

        CurrentPage = e.Page - 1;

        await GetPatientsAsync();

        await InvokeAsync(StateHasChanged);
    }

    private void OnFilteredDataChanged(DataGridFilteredDataEventArgs<PatientDto> e)
    {
        var test = DataGrid;
    }
}