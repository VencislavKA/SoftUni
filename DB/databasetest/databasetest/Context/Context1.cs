using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace databasetest.Context
{
    public class Context1 : DbContext
    {
        public Context1()
        {

        }
        public Context1(DbContextOptions<Context1> options)
            :base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Recipies;Integrated Security=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class1>().Property(x => x.Desc).HasColumnName("de");
        }
        public DbSet<Class1> Class1s { get; set; }
    }
}
