using DormCoreApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormCoreApp.Config
{
    public class RoomConfig
    {
        public static void OnModelCreating(EntityTypeBuilder<Room> builder)
        {
            builder.Property(a => a.Id).HasField("ID").HasMaxLength(12).IsRequired();
            builder.Property(a => a.RoomNo).HasField("ROOM_NO").HasMaxLength(12).IsRequired();
            builder.Property(a => a.Capacity).HasField("CAPACITY").HasMaxLength(12).IsRequired();
            builder.Property(a => a.Story).HasField("STORY").HasMaxLength(12).IsRequired();
            builder.Property(a => a.IsDeleted).HasField("IS_DELETED").HasMaxLength(12).IsRequired();
            builder.Property(a => a.DormId).HasField("DORM_ID").HasMaxLength(12).IsRequired();
        }
    }
}
