using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class Employee
{
    public long Id { get; set; }

    public string? EmployeeCode { get; set; }

    public string? EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? Department { get; set; }

    public string? Designation { get; set; }
}
