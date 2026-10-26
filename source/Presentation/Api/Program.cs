using Microsoft.EntityFrameworkCore;
using MSALAWI.Application;
using MSALAWI.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MSALAWI")
    ?? throw new InvalidOperationException("Connection string 'MSALAWI' is required.");

builder.Services.AddDbContext<MsalawiDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IPersonRepository, EfPersonRepository>();
builder.Services.AddScoped<CreatePersonHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.MapGet("/health", () => Results.Ok(new
{
    service = "MSALAWI.Presentation.Api",
    status = "Healthy",
    utc = DateTimeOffset.UtcNow
}));

// Security gate: People API remains unavailable until authentication,
// authorized tenant resolution, and tenant-scoped persistence are implemented.
// Do not re-enable this endpoint based on client-supplied tenant IDs.
app.MapPost("/api/people", () => Results.Problem(
    title: "People API is not enabled",
    detail: "Authentication and tenant isolation must be implemented first.",
    statusCode: StatusCodes.Status503ServiceUnavailable));

app.Run();
