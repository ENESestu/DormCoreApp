using DormCoreApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormCoreApp.Config
{
    public class DormConfig
    {
        public static void OnModelCreating(EntityTypeBuilder<Dorm> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasField("ID").HasMaxLength(12).IsRequired();
            builder.Property(d => d.Name).HasField("NAME").HasMaxLength(12).IsRequired();
            builder.Property(d => d.Address).HasField("ADDRESS").HasMaxLength(12).IsRequired();
            builder.Property(d => d.PhoneNumber).HasField("PHONE_NUMBER").HasMaxLength(12).IsRequired();
            builder.Property(d => d.ImageFilePath).HasField("IMAGE_FILE_PATH").HasMaxLength(12).IsRequired();
            builder.Property(d => d.IsDeleted).HasField("IS_DELETED").HasMaxLength(12).IsRequired();
        }
    }
}
