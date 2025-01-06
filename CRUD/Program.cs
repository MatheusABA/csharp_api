using CRUD.Data;
using CRUD.Routes;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();       // Swagger Documentation
builder.Services.AddDbContext<PersonContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("PostgresString");
    options.UseNpgsql(connectionString);
});    // Database Connection Context

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Routes
app.PersonRoutes();


// Running the app
app.UseHttpsRedirection();
app.Run();
