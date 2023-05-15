﻿using System;
using System.Collections.Generic;

namespace WebAPICRUD.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Userrole> Userroles { get; set; } = new List<Userrole>();
}
