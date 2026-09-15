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

app.MapPost("/api/people", async (CreatePersonCommand command, CreatePersonHandler handler, CancellationToken cancellationToken) =>
{
    var result = await handler.HandleAsync(command, cancellationToken);
    return result.IsSuccess
        ? Results.Created($"/api/people/{result.Value!.Id}", result.Value)
        : Results.BadRequest(new { error = result.Error });
});

app.Run();
