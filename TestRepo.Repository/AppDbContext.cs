using Microsoft.EntityFrameworkCore;

namespace TestRepo.Repository;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    // public DbSet<User> Users { get; set; }
    public DbSet<Entities.User> Users { get; set; }
    public DbSet<Entities.Seller> Sellers { get; set; }
    public DbSet<Entities.Product> Products { get; set; }
    public DbSet<Entities.Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var admin = new Entities.User
        {
            Id = Guid.NewGuid(),
            Role = "Admin",
            Email = "admin@gmail.com",
            Password = "PiedP"
        };
        modelBuilder.Entity<Entities.User>().HasData(admin);
    }
}