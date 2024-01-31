using Infrastructure.SQL.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var dbConnection = "Server=localhost;Database=conf_manage;User Id=sa;Password=Docker@123;TrustServerCertificate=True;";
builder.Services.AddDbContext<ConfContext>(options => options.UseSqlServer(dbConnection, b => b.MigrationsAssembly("api_conf_manage")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
