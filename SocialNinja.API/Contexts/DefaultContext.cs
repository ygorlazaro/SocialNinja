using Microsoft.EntityFrameworkCore;
using SocialNinja.API.Models;

namespace SocialNinja.API.Contexts;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<News> News { get; set; } = default!;
    public DbSet<Follower> Followers { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=SocialNinja.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Followings)
            .WithOne(n => n.User)
            .HasForeignKey(n => n.UserId);

        modelBuilder.Entity<Follower>()
            .HasOne(f => f.User)
            .WithMany(u => u.Followings)
            .HasForeignKey(f => f.FollowerId);

        base.OnModelCreating(modelBuilder);
    }
}
