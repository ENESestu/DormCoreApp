using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstAppEF.Models;

[Table("AUTHORITY")]
public partial class Authority
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DESCRIPTION")]
    [StringLength(100)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [Column("ROLE_ID")]
    public int RoleId { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Authorities")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Authorities")]
    public virtual User User { get; set; } = null!;
}
