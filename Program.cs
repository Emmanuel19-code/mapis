using mapis.Domain;
using mapis.Infrastructure;
using mapis.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.FileProviders;
using mapis.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDatabase"), sqlOptions => sqlOptions.EnableRetryOnFailure()));

// Register services
builder.Services.AddScoped<IApplicantsService, ApplicantService>();
builder.Services.AddScoped<IAdminService, AdminServices>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configuring SignalR
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:3000","http://localhost:3001") // Allow only the React frontend
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials(); // Allow credentials
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

// Serving Static Files
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Upload")),
    RequestPath = "/Upload"
});

app.UseCors("AllowSpecificOrigins"); // Apply the CORS policy that allows specific origins

app.UseHttpsRedirection();
app.MapControllers();

app.MapHub<NotificationHub>("/Notification");

app.Run();
