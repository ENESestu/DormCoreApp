using DormCoreApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DormCoreApp.Config
{
    public class RoleConfig
    {
        public static void OnModelCreating(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).HasField("ID").HasMaxLength(12).IsRequired();
            builder.Property(r => r.RoleName).HasField("ROLE_NAME").HasMaxLength(12).IsRequired();
        }
    }
}
