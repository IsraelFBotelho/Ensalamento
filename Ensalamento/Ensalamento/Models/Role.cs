using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ensalamento.Models
{
    [Table("role")]
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(64)]
        public string Name { get; set; }

        [InverseProperty(nameof(User.Role))]
        public virtual ICollection<User> Users { get; set; }
    }
}
