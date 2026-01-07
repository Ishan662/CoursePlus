using AutoMapper;
using CoursePlus.Application;
using CoursePlus.Application.Interfaces.Courses;
using CoursePlus.Application.Services;
using CoursePlus.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CoursePlusContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DbContext"),
        providerOptions => providerOptions.EnableRetryOnFailure()
    );
});



builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("My API");
        options.WithTheme(ScalarTheme.BluePlanet);
    });
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "openapi/v1.json";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
