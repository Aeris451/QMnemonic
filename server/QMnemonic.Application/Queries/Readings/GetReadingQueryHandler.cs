using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;
using MediatR;
using QMnemonic.Application.Queries.Readings;
using System.Runtime.CompilerServices;



namespace QMnemonic.Application.Queries.Readings;


public class GetReadingQueryHandler : IRequestHandler<GetReadingQuery, Reading>
{
    private readonly IReadingRepository _readingRepository;

    public GetReadingQueryHandler(IReadingRepository readingRepository)
    {
        _readingRepository = readingRepository;
    }


    public async Task<Reading> Handle(GetReadingQuery request, CancellationToken cancellationToken)
    {
        var reading = await _readingRepository.GetByIdAsync(request.ReadingId);



        return reading;
    }

}
