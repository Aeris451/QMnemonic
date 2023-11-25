using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace QMnemonic.Application.Queries.Languages
{
    public class GetLanguageQuery : IRequest
    {
        public int Id {get; set;}
    }
}