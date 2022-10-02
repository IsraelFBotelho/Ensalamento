using System;
using System.Collections.Generic;

#nullable disable

namespace Ensalamento.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Role Role { get; set; }
        public virtual Auth Auth { get; set; }
    }
}
