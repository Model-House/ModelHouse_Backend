using Microsoft.EntityFrameworkCore;
using ModelHouse.Interest.Domain.Models;
using ModelHouse.Profile.Domain.Models;
using ModelHouse.Security.Domain.Models;
using ModelHouse.Shared.Extensions;

namespace ModelHouse.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Users
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.Email).IsRequired();

        builder.Entity<User>()
            .HasMany(p => p.Orders)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        builder.Entity<User>()
            .HasMany(p => p.Posts)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        builder.Entity<User>()
            .HasMany(p => p.Areas)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        // Areas
        builder.Entity<Area>().ToTable("Areas");
        builder.Entity<Area>().HasKey(p => p.Id);
        builder.Entity<Area>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Area>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Area>().Property(p => p.Check).IsRequired();
        
        // Rooms
        builder.Entity<Room>().ToTable("Rooms");
        builder.Entity<Room>().HasKey(p => p.Id);
        builder.Entity<Room>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Room>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Room>().Property(p => p.Check).IsRequired();
        
        // Services
        builder.Entity<Service>().ToTable("Services");
        builder.Entity<Service>().HasKey(p => p.Id);
        builder.Entity<Service>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Service>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Service>().Property(p => p.Check).IsRequired();
        
        builder.Entity<Post>()
            .HasMany(p => p.Orders)
            .WithOne(p => p.Post)
            .HasForeignKey(p => p.PostId);
        
        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().HasKey(p => p.Id);
        builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().Property(p => p.Title).IsRequired().HasMaxLength(30);
        builder.Entity<Order>().Property(p => p.Description).IsRequired().HasMaxLength(200);

        builder.Entity<Post>().ToTable("Posts");
        builder.Entity<Post>().HasKey(p => p.Id);
        builder.Entity<Post>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Post>().Property(p => p.Price).IsRequired();
        builder.Entity<Post>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Post>().Property(p => p.Category).IsRequired().HasMaxLength(100);
        builder.Entity<Post>().Property(p => p.Location).IsRequired().HasMaxLength(100);
        builder.Entity<Post>().Property(p => p.Description).IsRequired().HasMaxLength(200);;
        builder.Entity<Post>().Property(p => p.Foto).IsRequired();
        
        builder.Entity<User>()
            .HasMany(p => p.Notifications)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        
        builder.Entity<Notification>().ToTable("Notifications");
        builder.Entity<Notification>().HasKey(p => p.Id);
        builder.Entity<Notification>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Notification>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Notification>().Property(p => p.Description).IsRequired().HasMaxLength(200);
        
        builder.Entity<User>()
            .HasMany(p => p.Contacts)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.ContactId);
        
        builder.Entity<Contact>().ToTable("Contacts");
        builder.Entity<Contact>().HasKey(p => p.Id);
        builder.Entity<Contact>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Contact>().Property(p => p.UserId).IsRequired();
        builder.Entity<Contact>().Property(p => p.ContactId).IsRequired();
        
        builder.Entity<Contact>()
            .HasMany(p => p.Messages)
            .WithOne(p => p.Contact)
            .HasForeignKey(p => p.ContactId);
        
        builder.Entity<Message>().ToTable("Messages");
        builder.Entity<Message>().HasKey(p => p.Id);
        builder.Entity<Message>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Message>().Property(p => p.Content).IsRequired();
        builder.Entity<Message>().Property(p => p.ShippingTime).IsRequired();
        builder.Entity<Message>().Property(p => p.isMe).IsRequired();
        builder.Entity<Message>().Property(p => p.UserId).IsRequired();
        builder.Entity<Message>().Property(p => p.ContactId).IsRequired();
        
        // Apply Naming Conventions
        builder.UseSnakeCaseNamingConvention();
    }
}