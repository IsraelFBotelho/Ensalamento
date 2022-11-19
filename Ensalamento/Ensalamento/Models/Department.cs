using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ensalamento.Models
{
    [Table("department")]
    [Index(nameof(CenterId), Name = "fk_department_center_id")]
    public partial class Department
    {
        public Department()
        {
            Classes = new HashSet<Class>();
            Users = new HashSet<User>();
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
        [Column("center_id")]
        public int? CenterId { get; set; }

        [ForeignKey(nameof(CenterId))]
        [InverseProperty("Departments")]
        public virtual Center Center { get; set; }
        [InverseProperty(nameof(Class.Department))]
        public virtual ICollection<Class> Classes { get; set; }
        [InverseProperty(nameof(User.Department))]
        public virtual ICollection<User> Users { get; set; }
    }
}
