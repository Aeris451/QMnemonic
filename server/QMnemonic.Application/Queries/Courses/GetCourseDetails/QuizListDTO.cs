using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Application.Queries.Quizzes
{
    public class QuizListDTO
    {
        public string Name {get; set;}
        public int Elements {get; set;}
        public int Order {get; set;}
        public int QuizId {get; set;}
        public string Description {get; set;}

    }
}