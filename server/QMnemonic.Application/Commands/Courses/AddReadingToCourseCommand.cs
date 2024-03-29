using System.Globalization;
using MediatR;
using QMnemonic.Domain.Repositories;
using QMnemonic.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.InteropServices;

namespace QMnemonic.Application.Commands.Courses
{
    public class AddReadingToCourseCommand : IRequest
    {
        public string Name {get; set;}
        public int CourseId {get; set;}
        public string Description {get; set;}
    }


}
