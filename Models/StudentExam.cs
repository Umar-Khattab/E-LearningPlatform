using System;
using System.Collections.Generic;

namespace E_LearningPlatform.Models;

public partial class StudentExam
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int ExamId { get; set; }

    public DateTime TimeToSubmit { get; set; }

    public virtual Exam Exam { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
