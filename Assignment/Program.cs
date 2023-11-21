using Application.Interfaces;
using Application.Services;
using Application.Services.Interfaces;
using Assignment.Middlewares;
using Infrastructure;
using Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigurationManager _config = builder.Configuration;
var origins = _config.GetSection("AllowedCorsURI").Get<string[]>();

builder.Services.AddCors(options =>
options.AddPolicy("AllowSpecific", p => p.WithOrigins(origins)
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .AllowCredentials()
                                      ));

builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseCors("AllowSpecific");
app.UseAuthorization();

app.MapControllers();

app.Run();
