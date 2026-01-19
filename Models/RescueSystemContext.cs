using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RescueSyetem_BE.Models;

public partial class RescueSystemContext : DbContext
{
    public RescueSystemContext()
    {
    }

    public RescueSystemContext(DbContextOptions<RescueSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DistDetail> DistDetails { get; set; }

    public virtual DbSet<Distribution> Distributions { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Mission> Missions { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamMember> TeamMembers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DistDetail>(entity =>
        {
            entity.HasKey(e => new { e.DistId, e.ItemId });

            entity.Property(e => e.DistId).HasColumnName("DistID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Dist).WithMany(p => p.DistDetails)
                .HasForeignKey(d => d.DistId)
                .HasConstraintName("FK_DistDetails_Dist");

            entity.HasOne(d => d.Item).WithMany(p => p.DistDetails)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DistDetails_Item");
        });

        modelBuilder.Entity<Distribution>(entity =>
        {
            entity.HasKey(e => e.DistId).HasName("PK__Distribu__118299D88C12C0B2");

            entity.Property(e => e.DistId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("DistID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Items__727E83EBB82D7D3F");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Stock).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Unit).HasMaxLength(20);
        });

        modelBuilder.Entity<Mission>(entity =>
        {
            entity.HasKey(e => e.MissionId).HasName("PK__Missions__66DFB85402047E98");

            entity.Property(e => e.MissionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("MissionID");
            entity.Property(e => e.DistributionId).HasColumnName("DistributionID");
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.Result).HasMaxLength(50);
            entity.Property(e => e.StartTime).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Assigned");
            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

            entity.HasOne(d => d.Distribution).WithMany(p => p.Missions)
                .HasForeignKey(d => d.DistributionId)
                .HasConstraintName("FK_Missions_Distribution");

            entity.HasOne(d => d.Request).WithMany(p => p.Missions)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Missions_Request");

            entity.HasOne(d => d.Team).WithMany(p => p.Missions)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Missions_Team");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Missions)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK_Missions_Vehicle");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Requests__33A8519AAB4CD784");

            entity.Property(e => e.RequestId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RequestID");
            entity.Property(e => e.CitizenId).HasColumnName("CitizenID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.DistType).HasDefaultValue(1);
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.Property(e => e.Lat).HasColumnType("decimal(10, 8)");
            entity.Property(e => e.Lng).HasColumnType("decimal(11, 8)");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.NumPeople).HasDefaultValue(1);
            entity.Property(e => e.RequestTime).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Citizen).WithMany(p => p.Requests)
                .HasForeignKey(d => d.CitizenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Requests_Citizen");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A454F80B0");

            entity.HasIndex(e => e.RoleCode, "UQ__Roles__D62CB59CAA96CF37").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RoleCode).HasMaxLength(50);
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Teams__123AE7B9A35D774C");

            entity.Property(e => e.TeamId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("TeamID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Lat).HasColumnType("decimal(10, 8)");
            entity.Property(e => e.Lng).HasColumnType("decimal(11, 8)");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Available");
            entity.Property(e => e.TeamName).HasMaxLength(100);
        });

        modelBuilder.Entity<TeamMember>(entity =>
        {
            entity.HasKey(e => new { e.TeamId, e.UserId });

            entity.HasIndex(e => e.TeamId, "UX_TeamMembers_OneLeader")
                .IsUnique()
                .HasFilter("([IsLeader]=(1))");

            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.JoinedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Team).WithOne(p => p.TeamMember)
                .HasForeignKey<TeamMember>(d => d.TeamId)
                .HasConstraintName("FK_TeamMembers_Team");

            entity.HasOne(d => d.User).WithMany(p => p.TeamMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamMembers_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC775E8E2C");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E44DF259AD").IsUnique();

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Role");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__Vehicles__476B54B2C0437B8C");

            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Available");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
