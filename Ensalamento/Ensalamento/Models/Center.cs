﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Ensalamento.Models
{
    public partial class Center
    {
        public Center()
        {
            Department = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }

        public virtual ICollection<Department> Department { get; set; }
    }
}