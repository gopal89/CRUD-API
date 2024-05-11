using ASPCoreWebApiCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly WebApiContext context;

        public StudentApiController(WebApiContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data =await context.Students.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var Student=await context.Students.FindAsync(id);
            if(Student == null)
            {
                return NotFound();
            }
            return Ok(Student);
        }

        [HttpPost]

        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Student>> UpdateStudent(int id,Student student)
        {
            if(id != student.StudentId)
            {
                return BadRequest();
            }
            context.Entry(student).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student==null)
            {
                return NotFound();
            }
            else
            {
                context.Students.Remove(student);
                await context.SaveChangesAsync();
                return Ok(student);
            }
            
            
        }
    }
}
