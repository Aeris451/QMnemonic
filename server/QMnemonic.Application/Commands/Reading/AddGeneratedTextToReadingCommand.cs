using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace QMnemonic.Application.Commands.Readings
{
    public class AddGeneratedTextToReadingCommand : IRequest
    {
        public List<int> QuizIds {get; set;}
        public int ReadingId {get; set;}
        public string Key {get; set;}
        public string Prompt {get; set;}
    }
}