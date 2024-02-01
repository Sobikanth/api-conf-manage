using System.Text;
using api_conf_manage.Mapping;
using api_conf_manage.Mapping.Interfaces;
using Azure.Identity;
using BLL.Services;
using Domain.Repositories;
using Domain.Services;
using Infrastructure.SQL.Database;
using Infrastructure.SQL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;


// using Infrastructure.SQL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var keyVaultUri = builder.Configuration.GetValue<string>("KeyVault:Uri");
builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUri), new DefaultAzureCredential());


var dbConnection = builder.Configuration.GetValue<string>("api-conf-manage");
builder.Services.AddDbContext<ConfContext>(options => options.UseSqlServer(dbConnection, b => b.MigrationsAssembly("api_conf_manage")));

var dbConnection_auth = builder.Configuration.GetValue<string>("api-conf-manage-auth");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dbConnection_auth, b => b.MigrationsAssembly("api_conf_manage")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
            ValidAudience = builder.Configuration["Jwt:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
        };
    });

//Services Registration

builder.Services.AddScoped<IUserRegisterService, UserRegisterService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRegisterModelMapper, UserRegisterModelMapper>();
builder.Services.AddScoped<IAttendeeMapper, AttendeeMapper>();
builder.Services.AddScoped<ILogInModelMapper, LogInModelMapper>();
builder.Services.AddScoped<IUserLogInService, UserLogInService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "Authentication_Test", Version = "v1" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Enteryour token in the text input below.",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[]{}
            }
        });
    });


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ConfContext>();
    db.Database.SetConnectionString(dbConnection);
    db.Database.Migrate();
}

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
