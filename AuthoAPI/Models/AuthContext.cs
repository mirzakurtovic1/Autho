using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AuthoAPI.Models
{
    public partial class AuthContext : DbContext
    {
        public AuthContext()
        {
        }

        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthUser> AuthUser { get; set; }
        public virtual DbSet<AuthUserFace> AuthUserFace { get; set; }
        public virtual DbSet<AuthUserImage> AuthUserImage { get; set; }
        public virtual DbSet<AuthUserUserGroup> AuthUserUserGroup { get; set; }
        public virtual DbSet<Enterance> Enterance { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventMaster> EventMaster { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Presence> Presence { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleEnterance> RoleEnterance { get; set; }
        public virtual DbSet<UserEnterance> UserEnterance { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Auth;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.Property(e => e.AccountCreatingDate).HasColumnType("datetime");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("passwordHash")
                    .HasMaxLength(100);

                entity.Property(e => e.PasswordSalt)
                    .HasColumnName("passwordSalt")
                    .HasMaxLength(100);

                entity.Property(e => e.QrCode)
                    .IsRequired()
                    .HasColumnName("qrCode")
                    .HasMaxLength(32)
                    .HasDefaultValueSql("('TestQR')");

                entity.Property(e => e.UserName).HasMaxLength(30);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AuthUser)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AuthUser__RoleId__46E78A0C");
            });

            modelBuilder.Entity<AuthUserFace>(entity =>
            {
                entity.HasOne(d => d.AuthUser)
                    .WithMany(p => p.AuthUserFace)
                    .HasForeignKey(d => d.AuthUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AuthUserF__AuthU__3E1D39E1");

                entity.HasOne(d => d.Presence)
                    .WithMany(p => p.AuthUserFace)
                    .HasForeignKey(d => d.PresenceId)
                    .HasConstraintName("FK__AuthUserF__Prese__57DD0BE4");
            });

            modelBuilder.Entity<AuthUserImage>(entity =>
            {
                entity.Property(e => e.AuthUserImage1).HasColumnName("AuthUserImage");

                entity.HasOne(d => d.AuthUser)
                    .WithMany(p => p.AuthUserImage)
                    .HasForeignKey(d => d.AuthUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AuthUserI__AuthU__40F9A68C");
            });

            modelBuilder.Entity<AuthUserUserGroup>(entity =>
            {
                entity.HasOne(d => d.AuthUser)
                    .WithMany(p => p.AuthUserUserGroup)
                    .HasForeignKey(d => d.AuthUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AuthUserU__AuthU__1AD3FDA4");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.AuthUserUserGroup)
                    .HasForeignKey(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AuthUserU__UserG__19DFD96B");
            });

            modelBuilder.Entity<Enterance>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Enterance)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enterance__Event__48CFD27E");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventDescription).HasMaxLength(256);

                entity.Property(e => e.EventEndingTime).HasColumnType("datetime");

                entity.Property(e => e.EventGroupId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasDefaultValueSql("('TxKgr3')");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.EventStartingTime).HasColumnType("datetime");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Event__EventType__47DBAE45");
            });

            modelBuilder.Entity<EventMaster>(entity =>
            {
                entity.Property(e => e.QrCode).HasColumnName("qrCode");

                entity.Property(e => e.QrCodeHash)
                    .HasColumnName("qrCodeHash")
                    .HasMaxLength(100);

                entity.Property(e => e.QrCodeSalt)
                    .HasColumnName("qrCodeSalt")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventMaster)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventMast__Event__4CA06362");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventMaster)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventMast__UserI__4BAC3F29");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(128);
            });

            modelBuilder.Entity<Presence>(entity =>
            {
                entity.Property(e => e.Notes).HasMaxLength(128);

                entity.Property(e => e.PresenceAttendingDateTime).HasColumnType("datetime");

                entity.Property(e => e.PresenceCreatingDateTime).HasColumnType("datetime");

                entity.Property(e => e.PresenceLeavingDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Presence)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Presence__EventI__4AB81AF0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Presence)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Presence__UserId__49C3F6B7");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(64);
            });

            modelBuilder.Entity<RoleEnterance>(entity =>
            {
                entity.Property(e => e.PermissionAddingDateTime).HasColumnType("datetime");

                entity.Property(e => e.UnlimitedAccess).HasColumnName("unlimitedAccess");

                entity.HasOne(d => d.Enterance)
                    .WithMany(p => p.RoleEnterance)
                    .HasForeignKey(d => d.EnteranceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoleEnter__Enter__5070F446");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleEnterance)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoleEnter__RoleI__4F7CD00D");
            });

            modelBuilder.Entity<UserEnterance>(entity =>
            {
                entity.Property(e => e.PermissionAddingTime).HasColumnType("datetime");

                entity.HasOne(d => d.Enterance)
                    .WithMany(p => p.UserEnterance)
                    .HasForeignKey(d => d.EnteranceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserEnter__Enter__4E88ABD4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEnterance)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserEnter__UserI__4D94879B");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
