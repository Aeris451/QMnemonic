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
using QMnemonic.Application.Commands.Quizzes;
using QMnemonic.Application.Queries.Quizs;
using QMnemonic.Application.Queries.Quizzes;





var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);



builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>(); 
builder.Services.AddScoped<IQuizRepository, QuizRepository>(); 

//builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();


builder.Services.AddScoped<IRequestHandler<CreateCourseCommand, int>, CreateCourseCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AddQuizToCourseCommand, int>, AddQuizToCourseCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AddQuestionToQuizCommand>, AddQuestionToQuizCommandHandler>();
//builder.Services.AddScoped<IRequestHandler<AddAnswersToQuizCommand>, AddAnswersToQuizCommandHandler>();



builder.Services.AddScoped<IRequestHandler<GetCoursesListQuery, List<CourseListDTO>>, GetCoursesListQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetCourseQuery, Course>, GetCourseQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetQuizQuery, Quiz>, GetQuizQueryHandler>();
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


