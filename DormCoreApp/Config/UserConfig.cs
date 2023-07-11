using DormCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DormCoreApp.Config
{
    public static class UserConfig
    {
        public static void OnModelCreating(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasField("ID").HasMaxLength(12).IsRequired();
            builder.Property(u => u.FirstName).HasField("FIRST_NAME").HasMaxLength(50).IsRequired();
            builder.Property(u => u.LastName).HasField("LAST_NAME").HasMaxLength(50).IsRequired();
            builder.Property(u => u.PhoneNumber).HasField("PHONE_NUMBER").HasMaxLength(12).IsRequired();
            builder.Property(u => u.Email).HasField("E_MAIL").HasMaxLength(12).IsRequired();
            builder.Property(u => u.UserName).HasField("USER_NAME").HasMaxLength(12).IsRequired();
            builder.Property(u => u.Password).HasField("PASSWORD").HasMaxLength(12).IsRequired();
            builder.Property(u => u.PictureFilePath).HasField("PICTURE_FILE_PATH").HasMaxLength(12).IsRequired();
            builder.Property(u => u.IsDeleted).HasField("IS_DELETED").HasMaxLength(12).IsRequired();
        }
    }
}
