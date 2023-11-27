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
using QMnemonic.Application.Mappings;
using System.Text.Json.Serialization;
using QMnemonic.Application.Commands.Readings;
using QMnemonic.Application.Queries.Readings;
using QMnemonic.Infrastructure.BardApi;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(MapperProfile));




builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>(); 
builder.Services.AddScoped<IQuizRepository, QuizRepository>(); 
builder.Services.AddScoped<IReadingRepository, ReadingRepository>(); 
builder.Services.AddScoped<IBardApiRepository, BardApi>(); 

//builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();


builder.Services.AddScoped<IRequestHandler<AddCourseCommand, int>, AddCourseCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AddQuizToCourseCommand, int>, AddQuizToCourseCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AddReadingToCourseCommand>, AddReadingToCourseCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AddTextToReadingCommand>, AddTextToReadingCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AddGeneratedTextToReadingCommand>, AddGeneratedTextToReadingCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AddQuestionToQuizCommand>, AddQuestionToQuizCommandHandler>();
//builder.Services.AddScoped<IRequestHandler<AddAnswersToQuizCommand>, AddAnswersToQuizCommandHandler>();



builder.Services.AddScoped<IRequestHandler<GetCoursesListQuery, List<CourseListDTO>>, GetCoursesListQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetCourseQuery, Course>, GetCourseQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetQuizQuery, Quiz>, GetQuizQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetReadingQuery, Reading>, GetReadingQueryHandler>();
//builder.Services.AddScoped<IRequestHandler<GetLanguageQuery, Language>, GetLanguageQueryHandler>();



builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                // inne opcje
            });


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


