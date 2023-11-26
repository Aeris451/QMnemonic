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
        public string SContent {get; set;}
        public string Content {get; set;}
        public string Annotations {get; set;}
        public string AnswerContent {get; set;}
    }
}