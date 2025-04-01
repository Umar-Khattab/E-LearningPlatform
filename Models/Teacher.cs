using System;
using System.Collections.Generic;

namespace E_LearningPlatform.Models;

public partial class Teacher : User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public int? Level { get; set; }

    public string? TeacherDegree { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }
}
