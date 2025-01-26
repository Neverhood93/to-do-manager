using ToDoManager.Infrastructure;
using ToDoManager.Application;
using ToDoManager.API;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddInfrastructureConfig(configuration);
builder.Services.AddApplicationConfig();
builder.Services.AddPresentationConfig();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();