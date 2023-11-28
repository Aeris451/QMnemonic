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
    public class AddGeneratedTextToReadingCommandHandler : IRequestHandler<AddGeneratedTextToReadingCommand>
    {
    private readonly IReadingRepository _readingRepository;

    private readonly IBardApiRepository _bardApiRepository;

    public AddGeneratedTextToReadingCommandHandler(IReadingRepository readingRepository, IBardApiRepository bardApiRepository)
    {
        _readingRepository = readingRepository;
        _bardApiRepository = bardApiRepository;
    }

        public async Task Handle(AddGeneratedTextToReadingCommand request, CancellationToken cancellationToken)
        {
            var reading = await _readingRepository.GetByIdAsync(request.ReadingId);

            var contents = await _readingRepository.GetQuestionContents(request.QuizIds);


            string toGen = string.Join("; ", contents);


            

            var newText = new Text
            {
                OrgContent = await _bardApiRepository.Generator(request.Prompt, toGen, request.Key),
                ConvContent = String.Empty
            };


            reading.Texts.Add(newText);

            await _readingRepository.UpdateAsync(reading);

        }
    }
}