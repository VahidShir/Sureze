using System.Collections.Generic;

namespace Sureze.Blazor.Pages;

public partial class Test : SurezeComponentBase
{
    //public Employee Employee { get; set; }

    //private List<Employee> employeeList = new() { new() { FirstName = "David" }, new() { FirstName = "Mladen" }, new() { FirstName = "John" }, new() { FirstName = "Ana" }, new() { FirstName = "Jessica" } };
}

public class Employee
{
    public string FirstName { get; set; }
}