using DemoCRUDWithDapper.Config;
using DemoCRUDWithDapper.Helpers;
using DemoCRUDWithDapper.Interface;
using DemoCRUDWithDapper.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
var encryptedConn = builder.Configuration["ConnectionStrings:DefaultConnection_Encrypted"];
var key = Environment.GetEnvironmentVariable("MY_AES_KEY");

if (string.IsNullOrWhiteSpace(key))
    throw new Exception("Environment variable MY_AES_KEY is missing.");

var decryptedConn = AesEncryption.Decrypt(encryptedConn, key);

builder.Services.AddSingleton(new DbConfig { ConnectionString = decryptedConn });

builder.Services.AddScoped<IDbConnection>(sp =>
{
    var config = sp.GetRequiredService<DbConfig>();
    return new SqlConnection(config.ConnectionString);
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProduct, ProductRepo>();


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
