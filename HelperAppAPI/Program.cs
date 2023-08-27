using HelperAppAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TODO_API.Data;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("SqLiteConnection")));
string SQLConnectionString = builder.Configuration.GetConnectionString("MariaDBConnection")!;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = false,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = c =>
        {
            Console.WriteLine(c.ToString());
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddScoped<JwtService>();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql(SQLConnectionString, ServerVersion.AutoDetect(SQLConnectionString)));
builder.Services.AddIdentityCore<IdentityUser>(options => builder.Configuration.GetValue<IdentityOptions>("IdentitySettings")).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllers();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();

app.Run();
