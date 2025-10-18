using CQRS_Pattern.AppDBContext;
using CQRS_Pattern.Entity;
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

        public StudentController(MyDBContext context) => _context = context;

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<Student?> GetByID(Guid id)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.ID == id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<Student> CreateStudent([FromBody] Student student)
        {
            student.ID = Guid.NewGuid();
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
