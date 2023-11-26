using MediatR;
using Microsoft.AspNetCore.Mvc;
using QMnemonic.Application.Commands.Courses;
using QMnemonic.Application.Queries.Courses;
using QMnemonic.Application.Queries.Quizzes;
using QMnemonic.Domain.Entities;
using System.Threading.Tasks;

namespace QMnemonic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost]
        [Route("api/[controller]/create")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
            
            var Courseid = await _mediator.Send(command);

            return Ok(Courseid);
        }


        [HttpPost]
        [Route("api/[controller]/course/createquiz")]
        public async Task<IActionResult> CreateQuiz([FromBody] AddQuizToCourseCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }
            
            var Quizid = await _mediator.Send(command);

            return Ok(Quizid);
        }



/*
        [HttpGet("{language}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses(int LanguageId)
        {

            var query = new GetCoursesListQuery { Language = languageId };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        */

        // Kontroler dla wybranego kursu
        [HttpGet("{language}/{courseId}/{courseTitle}")]
        public async Task<ActionResult<Course>> GetCourse(string language, int courseId, string courseTitle)
        {
            var command = new GetCourseQuery { Id = courseId };//, Language = language };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet("{courseId}/{language}/{quizId}")]
        public async Task<ActionResult<Quiz>> GetQuiz(int courseId, string language, int quizId)
        {
            // Tutaj możesz użyć odpowiedniego mechanizmu do pobrania quizu dla danego kursu i quizu
            var query = new GetQuizQuery { /*CourseId = courseId, Language = language,*/ Id = quizId };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
