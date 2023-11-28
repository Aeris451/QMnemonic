using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QMnemonic.Application.Commands.Quizzes;
using QMnemonic.Application.Queries.Quizzes;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Api.Controllers
{
    [ApiController]
    [Route("api/quiz")]

    
    public class QuizController : ControllerBase
    {

        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddQuestions([FromBody] AddQuestionToQuizCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
            
            await _mediator.Send(command);
            


            return Ok();
        }


        [HttpGet("{quizId}")]
        public async Task<ActionResult<Quiz>> GetQuiz(int quizId)
        {
            var query = new GetQuizQuery { QuizId = quizId };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }





    }
}