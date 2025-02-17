using mapis.Domain;
using mapis.Infrastructure;
using mapis.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using mapis.Hubs;
using Serilog;

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
builder.Services.AddScoped<IEventService,EventService>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configuring SignalR
builder.Services.AddSignalR();

//configuring logger
//builder.Host.ApplicationLoggerConfiguration();
Log.Logger = new LoggerConfiguration()
             .WriteTo.Console()
             .CreateLogger();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:3000","http://localhost:3001") 
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials(); 
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

app.UseCors("AllowSpecificOrigins"); 

app.UseHttpsRedirection();
app.MapControllers();

app.MapHub<NotificationHub>("/Notification");

app.Run();
