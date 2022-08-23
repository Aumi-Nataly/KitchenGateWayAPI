using Microsoft.EntityFrameworkCore;
using RecipeAPI.Contract;
using RecipeAPI.RepDB.RecipeDB;
using RecipeAPI.Service;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("RecipeDB");
builder.Services.AddDbContext<RecipeDBContext>(options => options.UseSqlServer(connectionString));

builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Seq("http://localhost:5341"));

builder.Services.AddScoped<IManagmentRecipe, ManagmentRecipe>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
app.UseExceptionHandler("/Error");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run("https://localhost:7206");

