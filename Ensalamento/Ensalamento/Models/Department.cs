using System;
using System.Collections.Generic;

#nullable disable

namespace Ensalamento.Models
{
    public partial class Department
    {
        public Department()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public int? CenterId { get; set; }

        public virtual Center Center { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
