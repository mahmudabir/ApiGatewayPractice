using ApiGateway;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddReverseProxy()
       .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// Bind SwaggerUI config
var swaggerUIConfig = new SwaggerUIOptionsSettings();
builder.Configuration.GetSection("SwaggerUI").Bind(swaggerUIConfig);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var endpoint in swaggerUIConfig.Endpoints)
        {
            options.SwaggerEndpoint(endpoint.Url, endpoint.Name);
        }
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapReverseProxy();
app.Run();
