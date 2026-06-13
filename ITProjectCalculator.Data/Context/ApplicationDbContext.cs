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
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(255);
            entity.Property(u => u.PasswordHash).HasMaxLength(500);
            entity.Property(u => u.Position).HasMaxLength(100);
            
            // Roles as JSON
            entity.Property(u => u.Roles)
                .HasConversion(
                    v => System.Text.Json.JsonSerializer.Serialize(v, new System.Text.Json.JsonSerializerOptions()),
                    v => System.Text.Json.JsonSerializer.Deserialize<List<string>>(v, new System.Text.Json.JsonSerializerOptions()) ?? new())
                .HasColumnType("nvarchar(max)");
            
            // AssignedWorkspaceIds as JSON
            entity.Property(u => u.AssignedWorkspaceIds)
                .HasConversion(
                    v => System.Text.Json.JsonSerializer.Serialize(v, new System.Text.Json.JsonSerializerOptions()),
                    v => System.Text.Json.JsonSerializer.Deserialize<List<int>>(v, new System.Text.Json.JsonSerializerOptions()) ?? new())
                .HasColumnType("nvarchar(max)");
        });

        // Configure Workspace entity
        modelBuilder.Entity<Workspace>(entity =>
        {
            entity.HasKey(w => w.Id);
            entity.Property(w => w.Name).IsRequired().HasMaxLength(255);
            entity.Property(w => w.Subdomain).IsRequired().HasMaxLength(100);
            
            // UsersWithPermissions as JSON
            entity.Property(w => w.UsersWithPermissions)
                .HasConversion(
                    v => System.Text.Json.JsonSerializer.Serialize(v, new System.Text.Json.JsonSerializerOptions()),
                    v => System.Text.Json.JsonSerializer.Deserialize<Dictionary<int, string>>(v, new System.Text.Json.JsonSerializerOptions()) ?? new())
                .HasColumnType("nvarchar(max)");
            
            // ProjectIds as JSON
            entity.Property(w => w.ProjectIds)
                .HasConversion(
                    v => System.Text.Json.JsonSerializer.Serialize(v, new System.Text.Json.JsonSerializerOptions()),
                    v => System.Text.Json.JsonSerializer.Deserialize<List<int>>(v, new System.Text.Json.JsonSerializerOptions()) ?? new())
                .HasColumnType("nvarchar(max)");
        });

        // Configure Project entity
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(255);
            entity.Property(p => p.Description).HasMaxLength(2000);
            entity.Property(p => p.Status).HasMaxLength(50);
        });

        // Configure ProjectResource entity
        modelBuilder.Entity<ProjectResource>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Name).IsRequired().HasMaxLength(255);
            entity.Property(r => r.ResourceType).IsRequired().HasMaxLength(50);
            entity.Property(r => r.ServiceName).HasMaxLength(255);
            entity.HasOne<Project>()
                .WithMany(p => p.Resources)
                .HasForeignKey(r => r.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure Executor entity
        modelBuilder.Entity<Executor>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Patronymic).HasMaxLength(100);
            entity.Property(e => e.RegistrationType).HasMaxLength(50);
            entity.Property(e => e.MeasurementUnit).HasMaxLength(50);
        });

        // Configure ExecutorService entity
        modelBuilder.Entity<ExecutorService>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Name).IsRequired().HasMaxLength(255);
            entity.Property(s => s.MeasurementUnit).HasMaxLength(50);
            entity.HasOne<Executor>()
                .WithMany(e => e.Services)
                .HasForeignKey(s => s.ExecutorId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure Equipment entity
        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.PurchaseType).HasMaxLength(50);
            entity.Property(e => e.MeasurementUnit).HasMaxLength(50);
        });

        // Configure EquipmentService entity
        modelBuilder.Entity<EquipmentService>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Name).IsRequired().HasMaxLength(255);
            entity.Property(s => s.MeasurementUnit).HasMaxLength(50);
            entity.HasOne<Equipment>()
                .WithMany(e => e.Services)
                .HasForeignKey(s => s.EquipmentId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure Customer entity
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(255);
            entity.Property(c => c.CompanyName).HasMaxLength(255);
            entity.Property(c => c.FirstName).HasMaxLength(100);
            entity.Property(c => c.LastName).HasMaxLength(100);
            entity.Property(c => c.Position).HasMaxLength(100);
            entity.Property(c => c.Email).HasMaxLength(255);
            entity.Property(c => c.Phone).HasMaxLength(20);
            entity.Property(c => c.Address).HasMaxLength(500);
        });

        // Configure CompanySettings entity
        modelBuilder.Entity<CompanySettings>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.CompanyName).IsRequired().HasMaxLength(255);
            entity.Property(c => c.DirectorFirstName).HasMaxLength(100);
            entity.Property(c => c.DirectorLastName).HasMaxLength(100);
            entity.Property(c => c.DirectorPosition).HasMaxLength(100);
            entity.Property(c => c.Phone).HasMaxLength(20);
            entity.Property(c => c.Email).HasMaxLength(255);
        });
    }
}
