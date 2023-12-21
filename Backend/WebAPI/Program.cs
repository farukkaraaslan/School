using Bussiness;
using Dal;
using Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebAPI.Security;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEntityServices();
builder.Services.AddBusinessService();
builder.Services.AddDalServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
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
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
//builder.Services.AddAuthentication("Basic").AddScheme<BasicAuthenticationOption,BasicAutheticatonHandler>("Basic",null);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
    config =>
    {
        config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidIssuer = "jsga.edu.tr",
            ValidAudience="client.jsga.edu.tr",
            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nemutlutürkümdiyenenemutlutürkümdiyene")),
            ValidateIssuer=true,
            ValidateAudience=false,
            ValidateIssuerSigningKey=true
        };
    });

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
app.UseAuthentication();

app.MapControllers();

app.Run();
