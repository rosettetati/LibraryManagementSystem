using Microsoft.EntityFrameworkCore;
using Milestone05_WebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQLite database
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlite("Data Source=library.db"));

var app = builder.Build();

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<LibraryDbContext>();

    db.Database.EnsureCreated();
}

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();