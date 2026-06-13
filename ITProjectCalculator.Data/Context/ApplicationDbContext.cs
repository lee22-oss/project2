using Microsoft.EntityFrameworkCore;
using ITProjectCalculator.Data.Entities;

namespace ITProjectCalculator.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Workspace> Workspaces { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectResource> ProjectResources { get; set; }
    public DbSet<Executor> Executors { get; set; }
    public DbSet<ExecutorService> ExecutorServices { get; set; }
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<EquipmentService> EquipmentServices { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CompanySettings> CompanySettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure User entity
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
        modelBuilder.Entity<User>()
            .Property(u => u.Roles)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', System.StringSplitOptions.RemoveEmptyEntries).ToList());
        modelBuilder.Entity<User>()
            .Property(u => u.AssignedWorkspaceIds)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', System.StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

        // Configure Workspace entity
        modelBuilder.Entity<Workspace>()
            .HasKey(w => w.Id);
        modelBuilder.Entity<Workspace>()
            .Property(w => w.UsersWithPermissions)
            .HasConversion(
                v => System.Text.Json.JsonSerializer.Serialize(v),
                v => System.Text.Json.JsonSerializer.Deserialize<Dictionary<int, string>>(v) ?? new());
        modelBuilder.Entity<Workspace>()
            .Property(w => w.ProjectIds)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', System.StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

        // Configure Project entity
        modelBuilder.Entity<Project>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Resources)
            .WithOne()
            .HasForeignKey(r => r.ProjectId);

        // Configure Executor entity
        modelBuilder.Entity<Executor>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Executor>()
            .HasMany(e => e.Services)
            .WithOne()
            .HasForeignKey(s => s.ExecutorId);

        // Configure Equipment entity
        modelBuilder.Entity<Equipment>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Equipment>()
            .HasMany(e => e.Services)
            .WithOne()
            .HasForeignKey(s => s.EquipmentId);
    }
}
