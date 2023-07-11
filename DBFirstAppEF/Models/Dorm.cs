using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstAppEF.Models;

[Table("DORM")]
public partial class Dorm
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("NAME")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("ADDRESS")]
    [StringLength(50)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [Column("PHONE_NUMBER")]
    [StringLength(11)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column("IMAGE_FILE_PATH")]
    [StringLength(100)]
    [Unicode(false)]
    public string ImageFilePath { get; set; } = null!;

    [Column("IS_DELETED")]
    [StringLength(10)]
    [Unicode(false)]
    public string IsDeleted { get; set; } = null!;

    [InverseProperty("Dorm")]
    public virtual ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();

    [InverseProperty("Dorm")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
