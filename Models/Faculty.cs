using System;
using System.Collections.Generic;

namespace testMVCProject.Models;

public partial class Faculty
{
    public long Id { get; set; }

    public string FacultyName { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
