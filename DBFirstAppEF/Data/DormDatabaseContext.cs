using System;
using System.Collections.Generic;
using DBFirstAppEF.Models;
using Microsoft.EntityFrameworkCore;

namespace DBFirstAppEF.Data;

public partial class DormDatabaseContext : DbContext
{
    public DormDatabaseContext()
    {
    }

    public DormDatabaseContext(DbContextOptions<DormDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accommodation> Accommodations { get; set; }

    public virtual DbSet<Authority> Authorities { get; set; }

    public virtual DbSet<Dorm> Dorms { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DormDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accommodation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ACCOMMOD__3214EC27E955BD31");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .IsFixedLength();

            entity.HasOne(d => d.Dorm).WithMany(p => p.Accommodations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DORM_ID");

            entity.HasOne(d => d.RoomNoNavigation).WithMany(p => p.Accommodations)
                .HasPrincipalKey(p => p.RoomNo)
                .HasForeignKey(d => d.RoomNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROOM_NO");

            entity.HasOne(d => d.User).WithMany(p => p.Accommodations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USERS_ID");
        });

        modelBuilder.Entity<Authority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AUTHORIT__3214EC271203B033");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).IsFixedLength();

            entity.HasOne(d => d.Role).WithMany(p => p.Authorities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuthorityRoles");

            entity.HasOne(d => d.User).WithMany(p => p.Authorities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuthorityRolesUserId");
        });

        modelBuilder.Entity<Dorm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DORM__3214EC27A698B5C2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).IsFixedLength();
            entity.Property(e => e.ImageFilePath).IsFixedLength();
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .IsFixedLength();
            entity.Property(e => e.Name).IsFixedLength();
            entity.Property(e => e.PhoneNumber).IsFixedLength();
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROLES__3214EC2799AF0E2E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).IsFixedLength();
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROOM__3214EC27E0B25201");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsDeleted).IsFixedLength();

            entity.HasOne(d => d.Dorm).WithMany(p => p.Rooms).HasConstraintName("FK_RoomDorm");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USER__3214EC27FC69A536");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EMail).IsFixedLength();
            entity.Property(e => e.FirstName).IsFixedLength();
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .IsFixedLength();
            entity.Property(e => e.LastName).IsFixedLength();
            entity.Property(e => e.Password).IsFixedLength();
            entity.Property(e => e.PhoneNumber).IsFixedLength();
            entity.Property(e => e.PictureFilePath).IsFixedLength();
            entity.Property(e => e.UserName).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
