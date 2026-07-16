// Copyright (c) 2026 - opx
using Chinook.Db.Dev.DataContext;
using Chinook.Service.Dev;
using Opx.Api.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpxApiWeb(builder.Configuration);
builder.Services.AddOpxWebSocket<ChinookWebSocketHandler>();
builder.Services.AddOpxWebSocketMessageHandler<ArtistWatchMessageHandler>();
builder.Services.RegisterServices();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var skipDbWarmup = builder.Configuration.GetValue<bool>("SkipDbWarmup");
var app = builder.Build();

if (!skipDbWarmup)
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
        await dbContext.WarmupAsync();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseOpxApiProtection();

app.UseAuthorization();

app.UseOpxWebApiHandler();
app.UseOpxWebApiStatusCodePages();

app.MapControllers();
app.GenerateOpxApiDocs();

app.Run();
