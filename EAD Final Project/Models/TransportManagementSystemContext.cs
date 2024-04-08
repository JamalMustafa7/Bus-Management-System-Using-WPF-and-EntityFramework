using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EAD_Final_Project.Models;

public partial class TransportManagementSystemContext : DbContext
{
    public TransportManagementSystemContext()
    {
    }

    public TransportManagementSystemContext(DbContextOptions<TransportManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleEntry> VehicleEntries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Muneeb\\SQLEXPRESS02;Initial Catalog=TransportManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__Table__AB6E616520A07384");

            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.NumberPlateNumber).HasName("PK__Vehicle__C50F183612C74A24");

            entity.ToTable("Vehicle");

            entity.Property(e => e.NumberPlateNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numberPlateNumber");
            entity.Property(e => e.ChasisNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("chasisNumber");
            entity.Property(e => e.VType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("vType");
            entity.Property(e => e.YearOfRegistration).HasColumnName("yearOfRegistration");
        });

        modelBuilder.Entity<VehicleEntry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VehicleE__3213E83FBE4248C4");

            entity.ToTable("VehicleEntry");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.In)
                .HasColumnType("datetime")
                .HasColumnName("in");
            entity.Property(e => e.NumberPlateNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numberPlateNumber");
            entity.Property(e => e.Out)
                .HasColumnType("datetime")
                .HasColumnName("out");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.NumberPlateNumberNavigation).WithMany(p => p.VehicleEntries)
                .HasForeignKey(d => d.NumberPlateNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VehicleEn__numbe__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
