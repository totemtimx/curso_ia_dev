using GeminiMessageProcessor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar HttpClient para Gemini
builder.Services.AddHttpClient();

// Registrar servicios de la aplicación
builder.Services.AddScoped<IGeminiService, GeminiService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IMessageProcessorService, MessageProcessorService>();

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
