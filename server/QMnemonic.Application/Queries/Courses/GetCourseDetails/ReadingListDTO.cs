using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Application.Queries.Quizzes
{
    public class ReadingListDTO
    {
        public string Name {get; set;}
        public int Elements {get; set;}
        public int ReadingId {get; set;}
        public string Description {get; set;}

    }
}