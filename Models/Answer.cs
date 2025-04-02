using E_LearningPlatform.Interfaces;
using System;
using System.Collections.Generic;

namespace E_LearningPlatform.Models;

public partial class Answer:ISharedProperties
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public int StudentId { get; set; }

    public string StudentAnswer { get; set; } = null!;

    public int ExamId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Exam Exam { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
