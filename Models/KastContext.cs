using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KAsT_aPi.Models;

public partial class KastContext : DbContext
{
    public KastContext()
    {
    }

    public KastContext(DbContextOptions<KastContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameOfCart> GameOfCarts { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;uid=root;Database=kast");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("game");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(45)
                .HasColumnName("category");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.PriseIsDiscount).HasColumnName("prise is discount");
            entity.Property(e => e.Reviews)
                .HasMaxLength(45)
                .HasColumnName("reviews");
            entity.Property(e => e.Trailers)
                .HasMaxLength(45)
                .HasColumnName("trailers");
        });

        modelBuilder.Entity<GameOfCart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("game of cart");

            entity.HasIndex(e => e.GameId, "game id");

            entity.HasIndex(e => e.UserId, "id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GameId).HasColumnName("game id");
            entity.Property(e => e.UserId).HasColumnName("user id");

            entity.HasOne(d => d.Game).WithMany(p => p.GameOfCarts)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dsdsa");

            entity.HasOne(d => d.User).WithMany(p => p.GameOfCarts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("library");

            entity.HasIndex(e => e.GameId, "fdfdfads");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GameId).HasColumnName("game id");
            entity.Property(e => e.UserId).HasColumnName("user id");

            entity.HasOne(d => d.Game).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fdfdfads");

            entity.HasOne(d => d.GameNavigation).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idfdgfg");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Login)
                .HasMaxLength(32)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(544)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
