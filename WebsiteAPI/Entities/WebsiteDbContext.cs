using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebsiteAPI.models;

namespace WebsiteAPI.Entities;

public partial class WebsiteDbContext : DbContext
{
    public WebsiteDbContext()
    {
    }

    public WebsiteDbContext(DbContextOptions<WebsiteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<login> Login { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<login>(entity =>
        {
            entity.ToTable("logintable");
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.password).HasMaxLength(256).HasColumnName("password");
            entity.Property(e => e.username).HasMaxLength(256).HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
