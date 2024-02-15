using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using WebApplication1.contratos;
using WebApplication1.filtters;
using WebApplication1.Repositorios;
using WebApplication1.Repositorios.DataAcess;
using WebApplication1.services;
using WebApplication1.UseCases.leiloes.GetCurrent;
using WebApplication1.UseCases.offers.create_offer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below;
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});


builder.Services.AddScoped<IAuctionRepository, LeilaoRepositorio>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<iUserRepository, UserRepository>();
builder.Services.AddScoped<ILoggerUsers, LoggedUser>();

builder.Services.AddScoped<AuthenticationUserAttribute>();
builder.Services.AddScoped<LoggedUser>();
builder.Services.AddScoped<CreateOfferUseCase>();
builder.Services.AddScoped<GetCurrentLeilao>();
builder.Services.AddDbContext<projetoDBcontext>(options =>
{
    options.UseSqlite(@"Data Source=C:\Users\user\source\repos\Solution1\leilaoDbNLW.db");
});




builder.Services.AddHttpContextAccessor();

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
