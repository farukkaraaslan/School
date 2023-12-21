using Entity.Helper;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Context;

public class MyDbContext : DbContext
{
    public MyDbContext() : base() { }
    public MyDbContext(DbContextOptions options) : base(options) { }


    public DbSet<Class> Classes { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.ConnectionString);
    }

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }
    private void UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(entry => entry.Entity is BaseEntity && (entry.State == EntityState.Added || entry.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (BaseEntity)entry.Entity;
            var now = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                entity.CreatedDateTime = now;
            }

            entity.UpdatedDateTime= now;
        }
    }
}


