using Bussiness;
using Dal;
using Entity;
using WebAPI.Security;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEntityServices();
builder.Services.AddBusinessService();
builder.Services.AddDalServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Basic").AddScheme<BasicAuthenticationOption,BasicAutheticatonHandler>("Basic",null);

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder=> builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
