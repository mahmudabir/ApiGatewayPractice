using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Add this block to override base URL
    c.AddServer(new OpenApiServer
    {
        Url = "" // This should match the path configured in YARP
    });

    // Add this block to override base URL
    c.AddServer(new OpenApiServer
    {
        Url = "/student-service" // This should match the path configured in YARP
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
