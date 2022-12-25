using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1;

public partial class WineV2Context : DbContext
{
    public WineV2Context()
    {
    }

    public WineV2Context(DbContextOptions<WineV2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wine> Wines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=WineV2;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_name");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .HasColumnName("Second_name");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Role");
        });

        modelBuilder.Entity<Wine>(entity =>
        {
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Grade).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.YearOfAqing)
                .HasColumnType("date")
                .HasColumnName("Year_of_aqing");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
