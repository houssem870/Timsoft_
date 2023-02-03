using Microsoft.EntityFrameworkCore;
using timsoft.DataBase;
using timsoft.repositories;
using timsoft.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataBaseContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("Timsoft")));

builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
builder.Services.AddTransient<IQuestionService, QuestionService>();



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
