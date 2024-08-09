using DesignPatternSamples.Domain.Models;
using DesignPatternSamples.Domain.OptionMaybe;
using DesignPatternSamples.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternSamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionMonadPatternController : ControllerBase
    {
        [HttpGet]
        public IActionResult actionResult()
        {
            var studentRepo = new StudentRepository();

            int studentID = 2;
            var studentOption = Option<Student>.Some(studentRepo.GetStudentByID(studentID));
            var student1Response = string.Empty;
            var student2Response = string.Empty;


            if (studentOption.HasValue)
            {
                var student = studentOption.Value;
                student1Response = $"Student found: {student.Name}";
            }
            else
            {
                student1Response = "Student not found.";
            }

            // Output: Student found: Bob

            int nonExistentStudentID = 100;
            var nonExistentStudentOption = Option<Student>.Some(studentRepo.GetStudentByID(nonExistentStudentID));

            if (nonExistentStudentOption.HasValue)
            {
                var student = nonExistentStudentOption.Value;
                student2Response = $"Student found: {student.Name}";
            }
            else
            {
                student2Response = "Student not found.";
            }

            // Output: Student not found.
            return Ok(new { student1Response, student2Response });
        }





    }
}
