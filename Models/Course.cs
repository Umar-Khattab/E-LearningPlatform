using E_LearningPlatform.Interfaces;
using System;
using System.Collections.Generic;

namespace E_LearningPlatform.Models;

public partial class Course:ISharedProperties
{
    public int Id { get; set; }

    public string CourseName { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<StudentsCourse> StudentsCourses { get; set; } = new List<StudentsCourse>();

    public virtual ICollection<TeachersCourse> TeachersCourses { get; set; } = new List<TeachersCourse>();
}
