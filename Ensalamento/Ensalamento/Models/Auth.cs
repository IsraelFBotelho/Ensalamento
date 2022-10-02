using System;
using System.Collections.Generic;

#nullable disable

namespace Ensalamento.Models
{
    public partial class Auth
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual User User { get; set; }
    }
}
