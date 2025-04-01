using E_LearningPlatform.Interfaces;
using System;
using System.Collections.Generic;

namespace E_LearningPlatform.Models;

public partial class Exam:ISharedProperties
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int TeacherId { get; set; }

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public int ExamTime { get; set; }

    public int TotalPoints { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<ExamsQuestion> ExamsQuestions { get; set; } = new List<ExamsQuestion>();

    public virtual ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();

    public virtual User Teacher { get; set; } = null!;
}
