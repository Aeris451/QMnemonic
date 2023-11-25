using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QMnemonic.Application.Queries.Languages;

/*
namespace QMnemonic.Api.Controllers
{
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LanguageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguage(int id)
        {
            var query = new GetLanguageQuery { Id = id };
            var lang = await _mediator.Send(query);

            if (lang == null)
            {
                return NotFound(); 
            }

            return Ok(lang); 
        }
    }
}

*/