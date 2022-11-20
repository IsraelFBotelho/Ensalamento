using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ensalamento.Models
{
    [Table("center")]
    [Index(nameof(Acronym), Name = "acronym", IsUnique = true)]
    [Index(nameof(Name), Name = "name", IsUnique = true)]
    public partial class Center
    {
        public Center()
        {
            Departments = new HashSet<Department>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        [Column("acronym")]
        [StringLength(16)]
        public string Acronym { get; set; }

        [InverseProperty(nameof(Department.Center))]
        public virtual ICollection<Department> Departments { get; set; }
    }
}
