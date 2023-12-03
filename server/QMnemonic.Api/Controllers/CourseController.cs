using MediatR;
using Microsoft.AspNetCore.Mvc;
using QMnemonic.Application.Commands.Courses;
using QMnemonic.Application.Queries.Courses;
using QMnemonic.Application.Queries.Languages;
using QMnemonic.Application.Queries.Quizzes;
using QMnemonic.Domain.Entities;
using System.Threading.Tasks;

namespace QMnemonic.Api.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCourse([FromBody] AddCourseCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var Courseid = await _mediator.Send(command);

            return Ok(Courseid);
        }


        [HttpPost]
        [Route("createquiz")]
        public async Task<IActionResult> CreateQuiz([FromBody] AddQuizToCourseCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var Quizid = await _mediator.Send(command);

            return Ok(Quizid);
        }


        [HttpPost]
        [Route("createreading")]
        public async Task<IActionResult> CreateReading([FromBody] AddReadingToCourseCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return Ok();
        }







        [HttpPost]
        public async Task<ActionResult<IEnumerable<CourseListDTO>>> GetCourses(GetCoursesListQuery query)
        {

            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet("{courseId}")]
        public async Task<ActionResult<CourseDetailsDTO>> GetCourse(int courseId)
        {
            var query = new GetCourseQuery { Id = courseId };

            var result = await _mediator.Send(query);


            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }



        [HttpGet("language")]
        public async Task<ActionResult<List<Language>>> GetLanguages()
        {

            var query = new GetLanguagesQuery { };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


    }
}
