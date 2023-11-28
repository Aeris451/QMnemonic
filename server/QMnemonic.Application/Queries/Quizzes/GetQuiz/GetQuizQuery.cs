using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Application.Queries.Quizzes
{
    public class GetQuizQuery: IRequest<Quiz>
    {
        public int QuizId {get; set;}
    }
}