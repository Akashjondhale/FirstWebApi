using FirstWebApi.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace FirstWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class StudentsController : ControllerBase
    {
        static List<studentDTO> students = new List<studentDTO>
        {
            new studentDTO { Id = 1, Name = "Akash", Age = 26 },
            new studentDTO { Id = 2, Name = "Rahul", Age = 24 }
        };

        [HttpGet("GetStudentId/{ID}")]
        public IActionResult GetStudentId(int ID)
        {
            try
            {
                if (ID == 0)
                {
                    return Ok(students);
                }

                var temp = students.FirstOrDefault(s => s.Id == ID);

                if (temp == null)
                {
                    return NotFound("Student not found");
                }

                return Ok(temp);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] studentDTO studentdto)
        {
            try
            {
                studentdto.Id = students.Max(s => s.Id) + 1;
                students.Add(studentdto);
                return Ok(studentdto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("Update/{ID}")]
        public IActionResult upadate([FromBody] studentDTO studentdto, int ID)
        {
            try
            {
                var temp = students.FirstOrDefault(s => s.Id == ID);
                if (temp == null)
                {
                    return NotFound("Student not found");

                }
                temp.Name = studentdto.Name;
                temp.Age = studentdto.Age;
                return Ok(temp);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error"); 
            }
        }

        [HttpDelete("Delete/{ID}")]
        public IActionResult delete(int ID)
        {
            try
            {
                var temp = students.FirstOrDefault(s => s.Id == ID);
                if (temp == null)
                {
                    return NotFound("Student not found");

                }
                students.Remove(temp);
                return Ok("record deleted");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
