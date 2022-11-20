using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ensalamento.Models
{
    [Table("subject")]
    public partial class Subject
    {
        public Subject()
        {
            ClassReservations = new HashSet<ClassReservation>();
        }

        [Key]
        [Column("id")]
        [StringLength(16)]
        public string Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(64)]
        public string Name { get; set; }

        [InverseProperty(nameof(ClassReservation.Subject))]
        public virtual ICollection<ClassReservation> ClassReservations { get; set; }
    }
}
