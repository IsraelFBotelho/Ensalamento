using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ensalamento.Models
{
    [Table("class_reservation")]
    [Index(nameof(ClassId), Name = "fk_class_reservation_class_id")]
    [Index(nameof(RequesterId), Name = "fk_class_reservation_requester_id")]
    [Index(nameof(SubjectId), Name = "fk_class_reservation_subject_id")]
    public partial class ClassReservation
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("requester_id")]
        public int RequesterId { get; set; }
        [Required]
        [Column("subject_id")]
        [StringLength(16)]
        public string SubjectId { get; set; }
        [Required]
        [Column("class_id")]
        [StringLength(16)]
        public string ClassId { get; set; }
        [Column("start_date", TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column("end_date", TypeName = "datetime")]
        public DateTime EndDate { get; set; }

        [ForeignKey(nameof(ClassId))]
        [InverseProperty("ClassReservations")]
        public virtual Class Class { get; set; }
        [ForeignKey(nameof(RequesterId))]
        [InverseProperty(nameof(User.ClassReservations))]
        public virtual User Requester { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("ClassReservations")]
        public virtual Subject Subject { get; set; }
    }
}
