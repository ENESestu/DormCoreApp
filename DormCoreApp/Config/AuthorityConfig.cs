using DormCoreApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormCoreApp.Config
{
    public class AuthorityConfig
    {
        public static void OnModelCreating(EntityTypeBuilder<Authority> builder)
        {
            builder.Property(a => a.Id).HasField("ID").HasMaxLength(12).IsRequired();
            builder.Property(a => a.Description).HasField("DESCRIPTION").HasMaxLength(12).IsRequired();
            builder.Property(a => a.RoleId).HasField("ROLE_ID").HasMaxLength(12).IsRequired();
            builder.Property(a => a.UserId).HasField("USER_ID").HasMaxLength(12).IsRequired();
        }
    }
}
