using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using MediatR;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Repositories;

namespace QMnemonic.Application.Commands.Readings
{
    public class AddTextToReadingCommandHandler : IRequestHandler<AddTextToReadingCommand>
    {
    private readonly IReadingRepository _readingRepository;

    public AddTextToReadingCommandHandler(IReadingRepository readingRepository)
    {
        _readingRepository = readingRepository;
    }

        public async Task Handle(AddTextToReadingCommand request, CancellationToken cancellationToken)
        {
            var reading = await _readingRepository.GetByIdAsync(request.ReadingId);



            var newText = new Text
            {
                OrgContent = request.Content,
                ConvContent = String.Empty
            };

            reading.Texts.Add(newText);

            await _readingRepository.UpdateAsync(reading);

        }
    }
}