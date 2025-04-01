using E_LearningPlatform.Interfaces;
using System;
using System.Collections.Generic;

namespace E_LearningPlatform.Models;

public partial class ExamsQuestion: ISharedProperties
{
    public int Id { get; set; }

    public int ExamId { get; set; }

    public int QuestionId { get; set; }

    public decimal QuestionPoints { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Exam Exam { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
