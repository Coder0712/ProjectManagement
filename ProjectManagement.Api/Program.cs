using ProjectManagement.Application.Interfaces;
using ProjectManagement.Application.Services;
using ProjectManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IKanbanBoardService, KanbanBoardService>();
builder.Services.AddTransient<ICardsService, CardsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
