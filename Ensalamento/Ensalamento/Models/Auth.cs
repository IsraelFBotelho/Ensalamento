using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ensalamento.Models
{
    [Table("auth")]
    public partial class Auth
    {
        [Key]
        [Column("user_registration")]
        public int UserRegistration { get; set; }
        [Required]
        [Column("login")]
        [StringLength(64)]
        public string Login { get; set; }
        [Required]
        [Column("password")]
        [StringLength(40)]
        public string Password { get; set; }
    }
}
