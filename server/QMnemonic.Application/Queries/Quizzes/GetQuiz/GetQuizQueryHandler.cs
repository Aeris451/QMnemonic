using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using MediatR;
using QMnemonic.Application.Queries.Quizzes;
using System.Runtime.CompilerServices;
using System.ComponentModel;



namespace QMnemonic.Application.Queries.Quizzes;


public class GetQuizQueryHandler : IRequestHandler<GetQuizQuery, Quiz>
{
    private readonly IQuizRepository _quizRepository;

    public GetQuizQueryHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }


    public async Task<Quiz> Handle(GetQuizQuery request, CancellationToken cancellationToken)
    {
        var quiz = await _quizRepository.GetQuizFromCourse(request.CourseId, request.Order);



        return quiz;
    }

}
