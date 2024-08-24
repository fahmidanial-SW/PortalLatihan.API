using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PortalLatihan.Application.Services;
using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Domain;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data;
using PortalLatihan.Infrastructure.Data.Context;
using PortalLatihan.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PortalLatihanDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IInitialDataService, InitialDataService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<IRefRegionService, RefRegionService>();
builder.Services.AddScoped<IRefZoneService, RefZoneService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITrainingDiscountGroupService, TrainingDiscountGroupService>();
builder.Services.AddScoped<ITrainingDiscountCodeService, TrainingDiscountCodeService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ITrainingFeeService, TrainingFeeService>();
builder.Services.AddScoped<IStaffService, StaffService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<IRefRegionRepository, RefRegionRepository>();
builder.Services.AddScoped<IRefZoneRepository, RefZoneRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketStatusHistoryRepository, TicketStatusHistoryRepository>();
builder.Services.AddScoped<ITrainingDiscountCodeRepository, TrainingDiscountCodeRepository>();
builder.Services.AddScoped<ITrainingDiscountGroupRepository, TrainingDiscountGroupRepository>();
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
builder.Services.AddScoped<ITrainingFeeRepository, TrainingFeeRepository>();
builder.Services.AddScoped<ITrainingStatusHistoryRepository, TrainingStatusHistoryRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();

builder.Services.AddMemoryCache();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Training Portal API", Version = "v1" });
    c.SchemaGeneratorOptions.SchemaIdSelector = type =>
    {
        if (type.IsEnum)
        {
            return type.Name;
        }
        return type.FullName;
    };
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.MapControllers();

ApplyMigration();
app.Run();

void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _Db = scope.ServiceProvider.GetRequiredService<PortalLatihanDBContext>();
        _Db?.Database.Migrate();
    }
}