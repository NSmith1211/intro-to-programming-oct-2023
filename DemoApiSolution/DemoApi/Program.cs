using DemoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TemperatureConverterService>();
builder.Services.AddScoped<ICalculateFees, StandardFeeCalculator>();
builder.Services.AddScoped<ISystemTime, SystemTime>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/temperatures/farenheit/{temp:float}/celcius", (float temp, TemperatureConverterService service) =>
{
    return service.ConvertFtoC(temp);
});

app.MapGet("/temperatures/celcius/{temp:float}/farenheit", (float temp, TemperatureConverterService service) =>
{
    return Results.Ok();
});

app.Run(); //"Blocking Call"

public record ConversionResponse(float F, float C);

public partial class Program { }