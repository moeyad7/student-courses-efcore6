#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolData;
using SchoolDomain;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            return await _context.Students
                .Select(x => StudentToDTO(x))
                .ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return StudentToDTO(student);
        }

        private static StudentDTO StudentToDTO(Student student)
        {
            return new StudentDTO
            {
                Id = student.StudentId,
                Name = student.Name,
                Age = student.Age,
                GPA = student.GPA
            };
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentDTO studentDTO)
        {
            if (id != studentDTO.Id)
            {
                return BadRequest();
            }

            Student student = StudentFromDTO(studentDTO);
            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!StudentExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> CreateStudent(StudentDTO studentDTO)
        {
            Student student = StudentFromDTO(studentDTO);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetStudent), new { id = student.StudentId },student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Students.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Students.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private static Student StudentFromDTO(StudentDTO StudentDTO)
        {
            return new Student
            {
                StudentId = StudentDTO.Id,
                Name = StudentDTO.Name,
                Age = StudentDTO.Age,
                GPA = StudentDTO.GPA
            };
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }

    }
}
