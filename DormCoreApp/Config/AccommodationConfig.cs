using DormCoreApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormCoreApp.Config
{
    public class AccommodationConfig
    {
        public static void OnModelCreating(EntityTypeBuilder<Accomodation> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasField("ID").HasMaxLength(12).IsRequired();
            builder.Property(a => a.DateStart).HasField("DATE_START").HasMaxLength(12).IsRequired();
            builder.Property(a => a.DateEnd).HasField("DATE_END").HasMaxLength(12).IsRequired();
            builder.Property(a => a.IsDeleted).HasField("IS_DELETED").HasMaxLength(12).IsRequired();
            builder.Property(a => a.DormName).HasField("DORM_NAME").HasMaxLength(12).IsRequired();
            builder.Property(a => a.RoomNo).HasField("ROOM_NO").HasMaxLength(12).IsRequired();
            builder.Property(a => a.UserId).HasField("USER_ID").HasMaxLength(12).IsRequired();
        }
    }
}
