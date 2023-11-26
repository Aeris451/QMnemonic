using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using MediatR;
using QMnemonic.Application.Queries.Quizzes;
using System.Runtime.CompilerServices;



namespace QMnemonic.Application.Queries.Quizs;


public class GetQuizQueryHandler : IRequestHandler<GetQuizQuery, Quiz>
{
    private readonly ICourseRepository _courseRepository;

    public GetQuizQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }


    public async Task<Quiz> Handle(GetQuizQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(request.CourseId);
        var quiz = course.Quizzes.Skip(request.QuizOrder - 1).FirstOrDefault();



        return quiz;
    }

}
