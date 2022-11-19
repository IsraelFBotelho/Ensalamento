using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ensalamento.Models
{
    [Table("desk_type")]
    public partial class DeskType
    {
        public DeskType()
        {
            Classes = new HashSet<Class>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(32)]
        public string Name { get; set; }

        [InverseProperty(nameof(Class.DeskType))]
        public virtual ICollection<Class> Classes { get; set; }
    }
}
