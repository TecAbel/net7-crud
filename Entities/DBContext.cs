using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPICRUD.Entities;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("true")
                .HasColumnName("active");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.Image)
                .IsRequired()
                .HasColumnType("character varying")
                .HasColumnName("image");
            entity.Property(e => e.Lastname)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(400)
                .HasColumnName("password");
            entity.Property(e => e.Secondlastname)
                .HasMaxLength(200)
                .HasColumnName("secondlastname");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userroles_pkey");

            entity.ToTable("userroles");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Role).WithMany(p => p.Userroles)
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("userroles_roleid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Userroles)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("userroles_userid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
