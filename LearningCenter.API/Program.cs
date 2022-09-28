using LearningCenter.API.Interest.Domain.Repositories;
using LearningCenter.API.Interest.Domain.Services;
using LearningCenter.API.Interest.Persistence.Repositories;
using LearningCenter.API.Interest.Services;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Persistence.Repositories;
using LearningCenter.API.Learning.Services;
using LearningCenter.API.Profile.Domain.Repositories;
using LearningCenter.API.Profile.Domain.Services;
using LearningCenter.API.Profile.Persistence.Repositories;
using LearningCenter.API.Profile.Services;
using LearningCenter.API.Security.Authorization.Handlers.Implementations;
using LearningCenter.API.Security.Authorization.Handlers.Interfaces;
using LearningCenter.API.Security.Authorization.Middleware;
using LearningCenter.API.Security.Authorization.Settings;
using LearningCenter.API.Security.Domain.Repositories;
using LearningCenter.API.Security.Domain.Services;
using LearningCenter.API.Security.Persistence.Repositories;
using LearningCenter.API.Security.Services;
using LearningCenter.API.Shared.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// AppSettings Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// OpenAPI Configuration
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ACME Learning Center API",
        Description = "ACME Learning Center Web Services",
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

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());



// Add lower case routes
builder.Services.AddRouting(
    options => options.LowercaseUrls = true);


// CORS Service addition

builder.Services.AddCors();

// Dependency Injection Configuration

// Shared Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Learning Injection Configuration

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITutorialRepository, TutorialRepository>();
builder.Services.AddScoped<ITutorialService, TutorialService>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Security Injection Configuration

builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(LearningCenter.API.Learning.Mapping.ModelToResourceProfile), 
    typeof(LearningCenter.API.Learning.Mapping.ResourceToModelProfile),
    typeof(LearningCenter.API.Security.Mapping.ModelToResourceProfile), 
    typeof(LearningCenter.API.Security.Mapping.ResourceToModelProfile),
    typeof(LearningCenter.API.Interest.Mapping.ModelToResourceProfile), 
    typeof(LearningCenter.API.Interest.Mapping.ResourceToModelProfile),
    typeof(LearningCenter.API.Profile.Mapping.ResourceToModelProfile),
    typeof(LearningCenter.API.Profile.Mapping.ModelToResourceProfile)
    
    );



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


// Configure CORS

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure Error Handler Middleware

app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure JWT Handling

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();