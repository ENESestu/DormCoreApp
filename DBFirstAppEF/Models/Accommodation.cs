using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstAppEF.Models;

[Table("ACCOMMODATION")]
public partial class Accommodation
{
    [Key]
    [Column("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }

    [Column("DATE_START", TypeName = "date")]
    public DateTime DateStart { get; set; }

    [Column("DATE_END", TypeName = "date")]
    public DateTime DateEnd { get; set; }

    [Column("IS_DELETED")]
    [StringLength(2)]
    [Unicode(false)]
    public string? IsDeleted { get; set; }

    [Column("DORM_ID")]
    public int DormId { get; set; }

    [Column("ROOM_NO")]
    public int RoomNo { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [ForeignKey("DormId")]
    [InverseProperty("Accommodations")]
    public virtual Dorm Dorm { get; set; } = null!;

    public virtual Room RoomNoNavigation { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Accommodations")]
    public virtual User User { get; set; } = null!;
}
