using AuthorizationAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

////�����
//builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));

//// ��������� �����, ������� ����� ������ ������
//var secretKey = builder.Configuration.GetSection("JWTSettings:SecretKey").Value;
//var issuer = builder.Configuration.GetSection("JWTSettings:Issuer").Value;
//var audience = builder.Configuration.GetSection("JWTSettings:Audience").Value;
//var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));


//��
var connectionStringUsers = builder.Configuration.GetConnectionString("UserDB");
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlite(connectionStringUsers));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UserDbContext>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
