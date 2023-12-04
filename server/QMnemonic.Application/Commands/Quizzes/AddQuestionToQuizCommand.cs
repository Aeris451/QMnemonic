using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace QMnemonic.Application.Commands.Quizzes
{
    public class AddQuestionToQuizCommand : IRequest
    {
        public int QuizId {get; set;}

    }
}