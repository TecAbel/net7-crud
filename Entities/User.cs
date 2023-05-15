using System;
using System.Collections.Generic;

namespace WebAPICRUD.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Lastname { get; set; }

    public string Secondlastname { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Image { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Userrole> Userroles { get; set; } = new List<Userrole>();
}
