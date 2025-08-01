using ConversionService.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mal patrón: Registrar múltiples servicios innecesarios
builder.Services.AddSingleton<ConversionService.Services.TemperatureService>();
builder.Services.AddSingleton<ConversionService.Services.TemperatureService>();
builder.Services.AddSingleton<ConversionService.Services.DistanceService>();
builder.Services.AddSingleton<ConversionService.Services.DistanceService>();
builder.Services.AddSingleton<ConversionService.Services.WeightService>();
builder.Services.AddSingleton<ConversionService.Services.WeightService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mal patrón: Usar múltiples middlewares redundantes
app.UseLoggingMiddleware();
app.UseCustomLogging();
app.UseRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();
