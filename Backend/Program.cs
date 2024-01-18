using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TrackingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<TrackingService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost",
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithExposedHeaders("Content-Disposition");
    });
    });

// builder.Services.AddHttpsRedirection(options =>
// {
//     options.HttpsPort = 5141; // Of welke poort je ook hebt geconfigureerd voor HTTPS
// });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();

app.UseRouting();

// endpoints
app.MapPost("/api/tracking/click", (PageInteraction pageInteraction, [FromServices] TrackingService trackingService) =>
{
    trackingService.TrackClick(pageInteraction.Page);
    return Results.Ok();
})
.WithOpenApi();

app.MapPost("/api/tracking/hover", (PageInteraction pageInteraction, [FromServices] TrackingService trackingService) =>
{
    trackingService.TrackHover(pageInteraction.Page);
    return Results.Ok();
})
.WithOpenApi();

// database migraties bij opstarten:
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<TrackingContext>();
    dbContext.Database.Migrate();
}

app.Run();
