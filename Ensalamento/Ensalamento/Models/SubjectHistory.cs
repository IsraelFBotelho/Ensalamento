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
    [Index(nameof(SubjectId), Name = "fk_subject_history_subject_id")]
    [Index(nameof(UserRegistration), Name = "fk_subject_history_user_registration")]
    public partial class SubjectHistory
    {
        [Column("start_date", TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column("end_date", TypeName = "datetime")]
        public DateTime EndDate { get; set; }
        [Column("user_registration")]
        public int UserRegistration { get; set; }
        [Column("subject_id")]
        public int SubjectId { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; }
        [ForeignKey(nameof(UserRegistration))]
        public virtual User UserRegistrationNavigation { get; set; }
    }
}
