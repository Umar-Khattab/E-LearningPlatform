using System;
using System.Collections.Generic;

namespace E_LearningPlatform.Models;

public partial class ExamsQuestion
{
    public int Id { get; set; }

    public int ExamId { get; set; }

    public int QuestionId { get; set; }

    public decimal QuestionPoints { get; set; }

    public virtual Exam Exam { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
