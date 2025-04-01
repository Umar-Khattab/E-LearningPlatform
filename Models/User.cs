using E_LearningPlatform.Interfaces;
using System;
using System.Collections.Generic;

namespace E_LearningPlatform.Models;

public partial class User:ISharedProperties
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public int? Level { get; set; }

    public string? TeacherDegree { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();

    public virtual ICollection<StudentsCourse> StudentsCourses { get; set; } = new List<StudentsCourse>();

    public virtual ICollection<TeachersCourse> TeachersCourses { get; set; } = new List<TeachersCourse>();
}
