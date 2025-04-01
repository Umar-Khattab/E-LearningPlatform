using E_LearningPlatform.Interfaces;
using System;
using System.Collections.Generic;

namespace E_LearningPlatform.Models;

public partial class StudentsCourse: ISharedProperties
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateOnly EnrollmentDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
