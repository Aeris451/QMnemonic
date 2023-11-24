using MediatR;
using Microsoft.AspNetCore.Mvc;
using QMnemonic.Application.Commands.Courses;
using QMnemonic.Application.Queries.Courses;
using System.Threading.Tasks;

namespace QMnemonic.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var courseId = await _mediator.Send(command);

            
            return Ok(new { CourseId = courseId });
        }


        
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _mediator.Send(new GetCoursesListQuery());

            return Ok(courses);
        }

[HttpGet("{id}")]
public async Task<IActionResult> GetCourse(int id)
{
    var query = new GetCourseQuery { Id = id };
    var course = await _mediator.Send(query);

    if (course == null)
    {
        return NotFound(); // Zwróć 404 Not Found, jeśli kurs nie został znaleziony
    }

    return Ok(course); // Zwróć 200 OK z obiektem kursu
}

    }
}
