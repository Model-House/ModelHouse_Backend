using backend.Register.Domain.Models;
using backend.RemodelKing.Domain.Models;
using backend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace backend.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Business> Businesses { get; set; }
    public DbSet<BusinessProject> BusinessProjects { get; set; }
    
    public DbSet<Activity> Activities { get; set; }
    
    public DbSet<Portfolio> Portfolios { get; set; }
    
    public DbSet<Request> Requests { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Business>().ToTable("Business");
        builder.Entity<Business>().HasKey(p => p.Id);
        builder.Entity<Business>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Business>().Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Business>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Business>().Property(p => p.Phone).IsRequired();
        builder.Entity<Business>().Property(p => p.Description).IsRequired();
        builder.Entity<Business>().Property(p => p.Img).IsRequired();
        builder.Entity<Business>().Property(p => p.Address).IsRequired();
        builder.Entity<Business>().Property(p => p.Score).IsRequired();
        builder.Entity<Business>().Property(p => p.WebSite).IsRequired();
        builder.Entity<Business>().Property(p => p.Days).IsRequired();
        //builder.Entity<Business>().Property(p => p.ConfirmPassword).IsRequired();

            builder.Entity<Business>()
           .HasMany(p => p.BusinessProjects)
           .WithOne(p => p.Business)
           .HasForeignKey(p => p.BusinessId);
            builder.Entity<Business>()
                .HasMany(p => p.Portfolios)
                .WithOne(p => p.Business)
                .HasForeignKey(p => p.BusinessId);

            builder.Entity<Client>().ToTable("Clients");
            builder.Entity<Client>().HasKey(p => p.Id);
            builder.Entity<Client>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Client>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Client>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Client>().Property(p => p.Email).IsRequired();
            builder.Entity<Client>().Property(p => p.Phone).IsRequired();
            builder.Entity<Client>().Property(p => p.Address).IsRequired();
            builder.Entity<Client>().Property(p => p.Img).IsRequired();
    
            builder.Entity<Client>()
                .HasMany(p => p.Requests)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId);
            
        builder.Entity<Portfolio>().ToTable("Portfolios");
        builder.Entity<Portfolio>().HasKey(p => p.Id);
        builder.Entity<Portfolio>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Portfolio>().Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Portfolio>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Portfolio>().Property(p => p.Phone).IsRequired();
        builder.Entity<Portfolio>().Property(p => p.ContractDate).IsRequired();

        builder.Entity<Portfolio>()
            .HasMany(p => p.Activities)
            .WithOne(p => p.Portfolio)
            .HasForeignKey(p => p.PortfolioId);  

        builder.Entity<Activity>().ToTable("Activity");
        builder.Entity<Activity>().HasKey(p => p.Id);
        builder.Entity<Activity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Activity>().Property(p => p.Description).IsRequired();
        builder.Entity<Activity>().Property(p => p.Title).IsRequired().HasMaxLength(40);
        builder.Entity<Activity>().Property(p => p.StartDate).IsRequired();
        builder.Entity<Activity>().Property(p => p.FinishDate).IsRequired();
        
        
        builder.Entity<BusinessProject>().ToTable("BusinessProjects");
        builder.Entity<BusinessProject>().HasKey(p => p.Id);
        builder.Entity<BusinessProject>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<BusinessProject>().Property(p => p.Style).IsRequired().HasMaxLength(50);
        builder.Entity<BusinessProject>().Property(p => p.Description).IsRequired();
        builder.Entity<BusinessProject>().Property(p => p.Location).IsRequired().HasMaxLength(100);
        builder.Entity<BusinessProject>().Property(p => p.Img);
        builder.Entity<BusinessProject>().Property(p => p.Score);

        builder.Entity<Request>().ToTable("Requests");
        builder.Entity<Request>().HasKey(p => p.Id);
        builder.Entity<Request>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Request>().Property(p => p.BusinessName).IsRequired().HasMaxLength(50);
        builder.Entity<Request>().Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Request>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Request>().Property(p => p.Description).IsRequired().HasMaxLength(50);
        
        builder.Entity<Payment>().ToTable("Payments");
        builder.Entity<Payment>().HasKey(p => p.Id);
        builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p => p.CreditCard).IsRequired();
        builder.Entity<Payment>().Property(p => p.CardHolder).IsRequired();
        builder.Entity<Payment>().Property(p => p.CardIssuer).IsRequired();
        builder.Entity<Payment>().Property(p => p.CVV).IsRequired();
        builder.Entity<Payment>().Property(p => p.ExpiryDate).IsRequired();

        builder.Entity<Business>()
            .HasOne(p => p.Payment)
            .WithOne(p => p.Business)
            .HasForeignKey<Payment>(p => p.BusinessId);
        
        builder.UseSnakeCaseNamingConvention();
    }
}