using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using QMnemonic.Infrastructure.Data;
using QMnemonic.Infrastructure.Identity;
using QMnemonic.Application.Commands.Courses;
using QMnemonic.Application.Queries.Courses;
using MediatR;
using System.Reflection;
using QMnemonic.Infrastructure.Repositories;
using QMnemonic.Domain.Repositories;
using QMnemonic.Domain.Entities;
using QMnemonic.Application.Queries.Languages;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<IAsyncRepository<Course>, CourseRepository>();
builder.Services.AddScoped<IAsyncRepository<Language>, LanguageRepository>(); 
builder.Services.AddScoped<IAsyncRepository<Quiz>, QuizRepository>(); 

//builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();


builder.Services.AddScoped<IRequestHandler<CreateCourseCommand, int>, CreateCourseCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetCoursesListQuery, List<CourseListDTO>>, GetCoursesListQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetCourseQuery, Course>, GetCourseQueryHandler>();
//builder.Services.AddScoped<IRequestHandler<GetLanguageQuery, Language>, GetLanguageQueryHandler>();



builder.Services.AddControllers();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseRouting();
app.MapControllers(); 
app.Run();


