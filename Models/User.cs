using System;
using System.Collections.Generic;

namespace E_LearningPlatform.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public int? Level { get; set; }

    public string? TeacherDegree { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();
}
