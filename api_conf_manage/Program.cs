using api_conf_manage.Mapping;
using api_conf_manage.Mapping.Interfaces;
using Azure.Identity;
using BLL.Services;
using Domain.Repositories;
using Domain.Services;
using Infrastructure.SQL.Database;
using Infrastructure.SQL.Repositories;

// using Infrastructure.SQL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var keyVaultUri = builder.Configuration.GetValue<string>("KeyVault:Uri");
builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUri), new DefaultAzureCredential());


var dbConnection = builder.Configuration.GetValue<string>("api-conf-manage");
builder.Services.AddDbContext<ConfContext>(options => options.UseSqlServer(dbConnection, b => b.MigrationsAssembly("api_conf_manage")));

var dbConnection_auth = builder.Configuration.GetValue<string>("api-conf-manage-auth");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dbConnection_auth, b => b.MigrationsAssembly("api_conf_manage")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

//Services Registration

builder.Services.AddScoped<IUserRegisterService, UserRegisterService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRegisterModelMapper, UserRegisterModelMapper>();
builder.Services.AddScoped<IAttendeeMapper, AttendeeMapper>();
builder.Services.AddScoped<ILogInModelMapper, LogInModelMapper>();
builder.Services.AddScoped<IUserLogInService, UserLogInService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
