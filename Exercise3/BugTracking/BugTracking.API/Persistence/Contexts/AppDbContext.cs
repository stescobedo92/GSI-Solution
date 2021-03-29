using BugTracking.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;

namespace BugTracking.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Bug> Bugs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();//.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Surname).IsRequired().HasMaxLength(30);            

            builder.Entity<User>().HasData
            (
                new User { Id = 100, Name = "Sergio", Surname = "Triana Escobedo" },
                new User { Id = 101, Name = "Carlos", Surname = "Armando Diaz" },
                new User { Id = 102, Name = "Rafael", Surname = "Estrada Perez" },
                new User { Id = 103, Name = "Aurelio", Surname = "Prieto Aleman" },
                new User { Id = 104, Name = "Milton", Surname = "Diaz Canter" },
                new User { Id = 105, Name = "Rachel", Surname = "Medina Perez" }
            );

            builder.Entity<Project>().ToTable("Projects");
            builder.Entity<Project>().HasKey(p => p.Id);
            builder.Entity<Project>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Project>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Project>().Property(p => p.Description);
            builder.Entity<Project>().HasMany(p => p.Bugs).WithOne(p => p.Project).HasForeignKey(p => p.Id);

            builder.Entity<Project>().HasData
            (
                new Project
                {
                    Id = 100,
                    Name = "Project #1",
                    Description = "Description #1"
                },
                new Project
                {
                    Id = 101,
                    Name = "Project #2",
                    Description = "Description #2",
                },
                new Project
                {
                    Id = 102,
                    Name = "Project #3",
                    Description = "Description #3",
                },
                new Project
                {
                    Id = 103,
                    Name = "Project #4",
                    Description = "Description #4",
                }
            );

            builder.Entity<Bug>().ToTable("Bugs");
            builder.Entity<Bug>().HasKey(p => p.Id);
            builder.Entity<Bug>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();//.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<Bug>().Property(p => p.ProjectId).IsRequired();
            builder.Entity<Bug>().Property(p => p.Project).IsRequired();
            builder.Entity<Bug>().Property(p => p.Description);
            builder.Entity<Bug>().Property(p => p.Users);
        }

    }
}