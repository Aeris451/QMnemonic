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




        [HttpGet("Courses/{langCode}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses(string langCode)
        {

            var query = new GetCoursesListQuery { LangageCode = langCode };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet("{courseId}")]
        public async Task<ActionResult<Course>> GetCourse(int courseId)
        {
            var command = new GetCourseQuery { Id = courseId };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet("{courseId}/{order}")]
        public async Task<ActionResult<Quiz>> GetQuiz(int courseId, int order)
        {
            // Tutaj możesz użyć odpowiedniego mechanizmu do pobrania quizu dla danego kursu i quizu
            var query = new GetQuizQuery { CourseId = courseId, QuizOrder = order };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
