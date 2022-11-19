using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Ensalamento.Models
{
    [Table("user")]
    [Index(nameof(DepartmentId), Name = "fk_user_department_id")]
    [Index(nameof(RoleId), Name = "fk_user_role_id")]
    public partial class User
    {
        [Key]
        [Column("registration")]
        public int Registration { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(64)]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(64)]
        public string LastName { get; set; }
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("department_id")]
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Users")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Users")]
        public virtual Role Role { get; set; }
    }
}
