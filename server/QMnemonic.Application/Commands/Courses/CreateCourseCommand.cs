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
    public class CreateCourseCommand : IRequest<int>
    {
        public string Name{ get; set; }
        public string Description {get; set;} = String.Empty;
        public string ShortDescription {get; set;} = String.Empty;
        public int LanguageId {get; set;}
        public int AuthorId = 1;
    }


}
