using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QMnemonic.Application.Commands.Quizzes;

namespace QMnemonic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    
    public class QuizController : ControllerBase
    {

        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddAnswers([FromBody] AddQuestionToQuizCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
            
            await _mediator.Send(command);
            


            return Ok();
        }



/*
        [HttpPost]
        public async Task<IActionResult> AddAnswers([FromBody] AddAnswersToQuizCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
            
            await _mediator.Send(command);
            


            return Ok();
        }
        
    }
*/


    }
}