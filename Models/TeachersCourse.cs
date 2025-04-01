using E_LearningPlatform.Interfaces;
using System;
using System.Collections.Generic;

namespace E_LearningPlatform.Models;

public partial class TeachersCourse: ISharedProperties
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int CourseId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User Teacher { get; set; } = null!;
}
