using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using MediatR;
using QMnemonic.Application.Queries.Quizzes;



namespace QMnemonic.Application.Queries.Quizs;

  
public class GetQuizQueryHandler : IRequestHandler<GetQuizQuery, Quiz>
    {
        private readonly IQuizRepository _quizRepository;

        public GetQuizQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }


    public async Task<Quiz> Handle(GetQuizQuery request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetByIdAsync(request.Id);
            return quiz;
        }

    }
