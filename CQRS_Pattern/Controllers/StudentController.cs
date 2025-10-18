using CQRS_Pattern.AppDBContext;
using CQRS_Pattern.Entity;
using CQRS_Pattern.Features.CreateStudent;
using CQRS_Pattern.Features.GetStudentByID;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRS_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly ISender _sender;

        public StudentController (MyDBContext context, ISender sender) { _context = context; _sender = sender; }

        [HttpGet("GetALL")]
        public IEnumerable<Student> GetAll ()
        {
            return _context.Students.ToList( );
        }

        // GET api/<StudentController>/5
        [HttpGet]
        public async Task<Student?> GetByID (Guid ID)
        {
            return await _sender.Send(new GetStudentByIDCommand(ID));
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent (CreateStudentCommand command)
        {
            var Student = await _sender.Send(command);
            return Ok(Student);
        }
    }
}
