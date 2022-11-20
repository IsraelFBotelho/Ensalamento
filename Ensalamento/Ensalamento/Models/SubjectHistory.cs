using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ensalamento.Models
{
    [Keyless]
    [Table("subject_history")]
    [Index(nameof(StudentId), Name = "fk_subject_history_student_id")]
    [Index(nameof(SubjectId), Name = "fk_subject_history_subject_id")]
    [Index(nameof(TeacherId), Name = "fk_subject_history_teacher_id")]
    public partial class SubjectHistory
    {
        [Column("start_date", TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column("end_date", TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Required]
        [Column("subject_id")]
        [StringLength(16)]
        public string SubjectId { get; set; }
        [Column("student_id")]
        public int StudentId { get; set; }
        [Column("teacher_id")]
        public int TeacherId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual User Student { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public virtual User Teacher { get; set; }
    }
}
