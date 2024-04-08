using System;
using System.Collections.Generic;

namespace EAD_Final_Project.Models;

public partial class User
{
    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }
}
