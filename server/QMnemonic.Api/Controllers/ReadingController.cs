using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QMnemonic.Application.Commands.Quizzes;
using QMnemonic.Application.Commands.Readings;
using QMnemonic.Application.Queries.Readings;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class ReadingController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ReadingController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddText([FromBody] AddTextToReadingCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            await _mediator.Send(command);



            return Ok();
        }


        [HttpGet("{readingId}")]
        public async Task<ActionResult<Reading>> GetQuiz(int readingId)
        {
            var query = new GetReadingQuery { ReadingId = readingId };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }



    }
}