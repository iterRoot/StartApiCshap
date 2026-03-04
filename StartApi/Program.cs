

using Microsoft.EntityFrameworkCore;
using StartApi;
using StartApi.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInjection();
builder.Services.AddDatabase();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddMiddleWare();

app.MapGet("/migration", (MyDbContext context) => context.Database.Migrate());

app.MapGet("/reset", (MyDbContext context) =>
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();