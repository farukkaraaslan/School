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

    public MyDbContext(DbContextOptions<MyDbContext> options): base(options) { }

    public DbSet<Class> Classes { get; set; }
    public DbSet<Student> Students { get; set; }  
    public DbSet<Lesson> Lessons { get; set; }  
    public DbSet<Teacher> Teachers{ get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.ConnectionString);
    }
}
