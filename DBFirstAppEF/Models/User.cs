using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstAppEF.Models;

[Table("USERS")]
public partial class User
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("FIRST_NAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("LAST_NAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("PHONE_NUMBER")]
    [StringLength(11)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column("E_MAIL")]
    [StringLength(30)]
    [Unicode(false)]
    public string EMail { get; set; } = null!;

    [Column("USER_NAME")]
    [StringLength(10)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    [Column("PASSWORD")]
    [StringLength(20)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("PICTURE_FILE_PATH")]
    [StringLength(100)]
    [Unicode(false)]
    public string PictureFilePath { get; set; } = null!;

    [Column("IS_DELETED")]
    [StringLength(2)]
    [Unicode(false)]
    public string IsDeleted { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();

    [InverseProperty("User")]
    public virtual ICollection<Authority> Authorities { get; set; } = new List<Authority>();
}
