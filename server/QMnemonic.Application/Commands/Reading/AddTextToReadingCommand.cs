using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace QMnemonic.Application.Commands.Readings
{
    public class AddTextToReadingCommand : IRequest
    {
        public int CourseId {get; set;}
        public string Content {get; set;}
    }
}