using MediatR;
using Microsoft.AspNetCore.Mvc;
using QMnemonic.Application.Courses.Queries;
using System.Threading.Tasks;

namespace YourWebProject.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetCourseList()
        {
            try
            {
                var query = new GetCourseListQuery();
                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
