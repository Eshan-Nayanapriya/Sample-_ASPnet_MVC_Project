using System;
using System.Collections.Generic;

namespace testMVCProject.Models;

public partial class Department
{
    public long Id { get; set; }

    public string DepartmentName { get; set; } = null!;

    public long FacultyId { get; set; }

    public virtual Faculty Faculty { get; set; } = null!;
}
