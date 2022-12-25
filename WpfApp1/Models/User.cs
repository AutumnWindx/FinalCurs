using System;
using System.Collections.Generic;

namespace WpfApp1;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public virtual Role RoleNavigation { get; set; } = null!;
}
