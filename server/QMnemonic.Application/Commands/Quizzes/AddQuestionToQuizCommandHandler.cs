using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace QMnemonic.Application.Commands.Quizzes
{
    public class AddQuestionToQuizCommandHandler : IRequestHandler<AddQuestionToQuizCommand>
    {
    private readonly IQuizRepository _quizRepository;

    public AddQuestionToQuizCommandHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }

        public async Task Handle(AddQuestionToQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetByIdAsync(request.QuizId);


            var newQuestion = new Question
            {
                Content = request.Content,
                SContent = request.SContent,
                Annotations = request.Annotations,
                Answer = new Answer 
                {
                    Quiz = quiz,
                    Content = request.AnswerContent
                }
            };


            quiz.Questions.Add(newQuestion);
            
            await _quizRepository.UpdateAsync(quiz);

            
            
        }
    }
}