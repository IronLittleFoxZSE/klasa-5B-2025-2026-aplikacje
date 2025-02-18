using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PeopleDatabaseClassLibrary.Models;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PeopleDatabaseClassLibrary;

public partial class PeopleDBContext : DbContext
{
    public PeopleDBContext()
    {
    }

    public PeopleDBContext(DbContextOptions<PeopleDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adrese> Adreses { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=people;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Adrese>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.AdressId).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.Adress).WithMany(p => p.People)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_adress");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
