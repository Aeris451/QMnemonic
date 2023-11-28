using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;

namespace QMnemonic.Application.Queries.Languages
{
    public class GetLanguagesQueryHandler : IRequestHandler<GetLanguagesQuery, List<Language>>
    {
        private readonly ILanguageRepository _LanguageRepository;
        private readonly IMapper _mapper; 


        public GetLanguagesQueryHandler(ILanguageRepository LanguageRepository, IMapper mapper)
        {
            _LanguageRepository = LanguageRepository;
            _mapper = mapper;
        }


        public async Task<List<Language>> Handle(GetLanguagesQuery request, CancellationToken cancellationToken)
        {


            var Languages = await _LanguageRepository.GetAllAsync();
   
            
            

            return Languages.ToList<Language>();
        }
    }
}