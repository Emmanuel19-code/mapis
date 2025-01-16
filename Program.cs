using mapis.Domain;
using mapis.Infrastructure;
using mapis.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDatabase")));

// Register services
builder.Services.AddScoped<IApplicantsService, ApplicantService>();
builder.Services.AddScoped<IAdminService, AdminServices>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));  

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
