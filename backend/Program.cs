using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Persistence.Repositories;
using backend.Register.Services;
using backend.Register.Mapping;
using backend.RemodelKing.Domain.Repositories;
using backend.RemodelKing.Domain.Services;
using backend.RemodelKing.Persistence.Repositories;
using backend.RemodelKing.Services;
using backend.Security.Authorization.Handlers.Implementations;
using backend.Security.Authorization.Handlers.Interfaces;
using backend.Security.Authorization.Middleware;
using backend.Security.Authorization.Settings;
using backend.Security.Domain.Repositories;
using backend.Security.Domain.Services;
using backend.Security.Persistence.Repositories;
using backend.Security.Services;
using backend.Shared.Domain.Repositories;
using backend.Shared.Persistence.Contexts;
using backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "ACME RemodelKing API",
        Description = "ACME RemodelKing Web Services",
        Contact = new OpenApiContact
        {
            Name = "ACME.studio",
            Url = new Uri("https://acme.studio")
        },
        License = new OpenApiLicense
        {
            Name = "ACME RemodelKing resources License",
            Url = new Uri("https://acme-learning.com/license")
        } 
    });
    options.EnableAnnotations();
    options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "Jwt",
        Description = "Jwt Authorization header using Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "bearerAuth"
                }
            },
            Array.Empty<string>()

        }
    });

});
// AppSettings Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:3000").AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Add lower case routes
builder.Services.AddRouting(
    options => options.LowercaseUrls = true);

// Dependency Injection Configuration
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientServiceImpl>();
builder.Services.AddScoped<IBusinessService, BusinessServiceImpl>();
builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();;
builder.Services.AddScoped<IBusinessProjectService, BusinessProjectServiceImpl>();
builder.Services.AddScoped<IBusinessProjectRepository, BusinessProjectRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IActivityService, ActivityServiceImpl>();
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IPortfolioService, PortfolioServiceImpl>();
builder.Services.AddScoped<IRequestService, RequestServiceImpl>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentServiceImpl>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();

// Security Injection Configuration
builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IBusinessProfileRepository, BusinessProfileRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IClientProfileRepository, ClientProfileRepository>();
// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(backend.Register.Mapping.ModelToResourceProfile),
    typeof(backend.Register.Mapping.ResourceToModelProfile),
    typeof(backend.Security.Mapping.ModelToResourceProfile),
    typeof(backend.Security.Mapping.ResourceToModelProfile));

var app = builder.Build();

// Validation for Ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();