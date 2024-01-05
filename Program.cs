using _NET.Data;
using _NET.Services.MovieService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add database context and connection string to migrate database using EfCore
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder
    .Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
//Add Service to program.cs
builder.Services.AddScoped<IMovieService, MovieService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();   
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
