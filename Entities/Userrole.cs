using System;
using System.Collections.Generic;

namespace WebAPICRUD.Entities;

public partial class Userrole
{
    public Guid Id { get; set; }

    public Guid? Userid { get; set; }

    public int? Roleid { get; set; }

    public virtual Role Role { get; set; }

    public virtual User User { get; set; }
}
