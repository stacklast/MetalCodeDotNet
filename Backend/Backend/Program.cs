using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Backend.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IPeopleService, PeopleService>();
builder.Services.AddKeyedSingleton<IPeopleService, PeopleService>("peopleService");

builder.Services.AddKeyedSingleton<IRandomService, RandomService>("randomSingleton");

builder.Services.AddKeyedScoped<IRandomService, RandomService>("randomScoped");

builder.Services.AddKeyedTransient<IRandomService, RandomService>("randomTransient");

builder.Services.AddScoped<IPostsService, PostsService>();

//AddScoped una llamada por cada controllador
builder.Services.AddScoped<IBeerService, BeerService>();

//httpclient luego de los servicios
builder.Services.AddHttpClient<IPostsService, PostsService>( c => 
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
 });

//Entity Framework
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

//Validators
builder.Services.AddScoped<IValidator<BeerInsertDto>, BeerInsertValidator>();
builder.Services.AddScoped<IValidator<BeerUpdateDto>, BeerUpdateValidator>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
