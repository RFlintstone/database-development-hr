using Microsoft.EntityFrameworkCore;
using EFCore.Models;

namespace EFCore.DataStore;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    // public DbSet<PostsTable> Posts { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Dependent> Dependents { get; set; }
    public DbSet<DeptLocations> DeptLocations { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<WorksOn> WorksOn { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Do nothing
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<PostsTable>()
        //     .ToTable("posts");

        // Configure Employee-Supervisor relationship
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Supervisor)
            .WithMany()
            .HasForeignKey(e => e.Super_ssn)
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(false);

        // Configure Department-Employee relationship (One-to-Many)
        modelBuilder.Entity<Department>()
            .HasOne(d => d.Manager)
            .WithMany()
            .HasForeignKey(d => d.Mgr_ssn)
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(false);

        // Configure composite primary key for DeptLocations
        modelBuilder.Entity<DeptLocations>()
            .HasKey(dl => new {dl.Dnumber, dl.Dlocation});

        // Configure Project-Department relationship (Many-to-One)
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Department)
            .WithMany()
            .HasForeignKey(p => p.Dnum)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(true);

        // Configure WorkOn relationship (Many-to-Many between Employee and Project)
        modelBuilder.Entity<WorksOn>()
            .HasKey(wo => new {wo.Essn, wo.Pno});

        modelBuilder.Entity<WorksOn>()
            .HasOne(wo => wo.Employee)
            .WithMany()
            .HasForeignKey(wo => wo.Essn)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(true);

        modelBuilder.Entity<WorksOn>()
            .HasOne(wo => wo.Project)
            .WithMany()
            .HasForeignKey(wo => wo.Pno)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(true);

        // Configure the composite primary key for WorksOn
        modelBuilder.Entity<WorksOn>()
            .HasKey(w => new {w.Essn, w.Pno});

        // Configure the Department-Location relationship (Many-to-Many)
        modelBuilder.Entity<DeptLocations>()
            .HasKey(dl => new {dl.Dnumber, dl.Dlocation});

        // Configure the foreign key relationship between DeptLocations and Department
        modelBuilder.Entity<DeptLocations>()
            .HasOne(dl => dl.Department)
            .WithMany()
            .HasForeignKey(dl => dl.Dnumber)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the foreign key relationship between DeptLocations and Location
        modelBuilder.Entity<DeptLocations>()
            .HasOne(dl => dl.Location)
            .WithMany()
            .HasForeignKey(dl => dl.Dlocation)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the Dependent-Employee relationship (One-to-Many)
        modelBuilder.Entity<Dependent>()
            .HasKey(d => new {d.Essn, d.Dependent_name});

        modelBuilder.Entity<Dependent>()
            .HasOne(d => d.Employee)
            .WithMany()
            .HasForeignKey(d => d.Essn)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(true);
    }
}