using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Application.Queries.Languages
{
    public class GetLanguagesQuery : IRequest<List<Language>>
    {
        
    }
}