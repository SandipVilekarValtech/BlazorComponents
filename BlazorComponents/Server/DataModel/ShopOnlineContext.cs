using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorComponents.Server.DataModel;

public partial class ShopOnlineContext : DbContext
{
    public ShopOnlineContext()
    {
    }

    public ShopOnlineContext(DbContextOptions<ShopOnlineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("authors");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0)
                .HasColumnName("id");
            entity.Property(e => e.Added)
                .HasColumnOrder(5)
                .HasColumnName("added");
            entity.Property(e => e.Birthdate)
                .HasColumnOrder(4)
                .HasColumnType("date")
                .HasColumnName("birthdate");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnOrder(3)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnOrder(1)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnOrder(2)
                .HasColumnName("last_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
