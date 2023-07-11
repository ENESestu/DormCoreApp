using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstAppEF.Models;

[Table("ROOM")]
[Index("RoomNo", Name = "UQ__ROOM__2F3DEBD8050603E0", IsUnique = true)]
public partial class Room
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ROOM_NO")]
    public int RoomNo { get; set; }

    [Column("CAPACITY")]
    public int Capacity { get; set; }

    [Column("STORY")]
    public int Story { get; set; }

    [Column("IS_DELETED")]
    [StringLength(2)]
    public string IsDeleted { get; set; } = null!;

    [Column("DORM_ID")]
    public int? DormId { get; set; }

    public virtual ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();

    [ForeignKey("DormId")]
    [InverseProperty("Rooms")]
    public virtual Dorm? Dorm { get; set; }
}
