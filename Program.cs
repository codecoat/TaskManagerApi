var builder = WebApplication.CreateBuilder(args);

// Add CORS so Angular can call the API if needed
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();

var app = builder.Build();

// Enable CORS
app.UseCors("AllowAll");

// Serve static files from wwwroot (Angular build)
app.UseDefaultFiles(); // Looks for index.html by default
app.UseStaticFiles();  // Serves JS, CSS, assets

// Map API routes
app.MapControllers();

// Fallback route: any non-API route serves Angular app
app.MapFallbackToFile("index.html");

app.Run();
