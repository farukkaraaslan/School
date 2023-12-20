using Entity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEntityService();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder=> builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
