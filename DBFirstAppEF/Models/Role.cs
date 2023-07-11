using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstAppEF.Models;

[Table("ROLES")]
public partial class Role
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("NAME")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<Authority> Authorities { get; set; } = new List<Authority>();
}
