using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace task_manager_app
{
    class TaskManagerDbContext : DbContext
    {
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.Priority> Priorities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=TaskManagerDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Priority>().HasData(
                new Models.Priority() { PriorityId = 1, Title = "High" },
                new Models.Priority() { PriorityId = 2, Title = "Medium" },
                new Models.Priority() { PriorityId = 3, Title = "Low" }
            );
        }
    }
}
