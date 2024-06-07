using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RentalCar;

public partial class SaleCarDbContext : DbContext
{
    public SaleCarDbContext()
    {
    }

    public SaleCarDbContext(DbContextOptions<SaleCarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<RentalCar> RentalCars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSqlLocalDB;Initial Catalog=SaleCarDB;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC0762BA472E");

            entity.ToTable("Account");

            entity.Property(e => e.Aid)
                .HasMaxLength(10)
                .HasColumnName("AID");
            entity.Property(e => e.ChtName).HasMaxLength(50);
            entity.Property(e => e.MobilePhone).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cc).HasColumnName("cc");
            entity.Property(e => e.ManufacturingDate).HasColumnType("datetime");
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(200);
        });

        modelBuilder.Entity<RentalCar>(entity =>
        {
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.CarType).HasMaxLength(200);
            entity.Property(e => e.RentalEndTime).HasColumnType("datetime");
            entity.Property(e => e.RentalStartTime).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
