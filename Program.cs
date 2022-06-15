//Register Context 1 
using Microsoft.EntityFrameworkCore;
using csharp_webapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Register Context 2
builder.Services.AddDbContext<SingleActivityContext>(options => 
options.UseInMemoryDatabase("ListActivities"));


var app = builder.Build();

//Manage Index1
if(builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//Manage Index 2
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();