﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Ensalamento.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
