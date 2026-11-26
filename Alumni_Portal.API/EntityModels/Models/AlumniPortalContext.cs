using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityModels.Models
{
    public partial class AlumniPortalContext : DbContext
    {
        public AlumniPortalContext()
        {
        }

        public AlumniPortalContext(DbContextOptions<AlumniPortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<ContactDetail> ContactDetails { get; set; } = null!;
        public virtual DbSet<Institution> Institutions { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<MemberAddress> MemberAddresses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ContactDetail>(entity =>
            {
                entity.HasKey(e => e.ContactDetailsId);

                entity.Property(e => e.ContactDetailsId).ValueGeneratedNever();

                entity.Property(e => e.SocialMediaUrl).HasColumnName("SocialMediaURL");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.HasIndex(e => e.Code, "UQ__Institut__A25C5AA70B0870D7")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Logo).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.State).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('Active')");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Website).HasMaxLength(255);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasIndex(e => e.ContactDetailsId, "IX_Members_ContactDetailsId");

                entity.Property(e => e.MemberId).ValueGeneratedNever();

                entity.HasOne(d => d.ContactDetails)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.ContactDetailsId);
            });

            modelBuilder.Entity<MemberAddress>(entity =>
            {
                entity.Property(e => e.MemberAddressId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Roles__737584F6D0ACCF29")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D1053451B76FD7")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.ProfileImage).HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('Active')");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => new { e.InstitutionId, e.RoleId }, "IX_UserRoles_InstitutionRole");

                entity.HasIndex(e => new { e.UserId, e.InstitutionId, e.RoleId }, "UQ_UserRoles")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AssignedByNavigation)
                    .WithMany(p => p.UserRoleAssignedByNavigations)
                    .HasForeignKey(d => d.AssignedBy)
                    .HasConstraintName("FK__UserRoles__Assig__4F47C5E3");

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.InstitutionId)
                    .HasConstraintName("FK__UserRoles__Insti__4D5F7D71");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRoles__RoleI__4E53A1AA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRoles__UserI__4C6B5938");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
