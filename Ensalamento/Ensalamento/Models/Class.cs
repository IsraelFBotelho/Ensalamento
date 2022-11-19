using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ensalamento.Models
{
    [Table("class")]
    [Index(nameof(DepartmentId), Name = "fk_class_department_id")]
    [Index(nameof(DeskTypeId), Name = "fk_class_desk_type_id")]
    public partial class Class
    {
        [Key]
        [Column("id")]
        [StringLength(16)]
        public string Id { get; set; }
        [Column("type")]
        public int Type { get; set; }
        [Column("capacity")]
        public int Capacity { get; set; }
        [Column("acessible")]
        public bool Acessible { get; set; }
        [Column("desk_type_id")]
        public int DeskTypeId { get; set; }
        [Column("department_id")]
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Classes")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(DeskTypeId))]
        [InverseProperty("Classes")]
        public virtual DeskType DeskType { get; set; }
    }
}
