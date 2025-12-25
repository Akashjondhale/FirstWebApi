using FirstWebApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        [HttpGet("add")]
        public IActionResult Add(int a, int b)
        {
            int sum = a + b;
            return Ok("sum =>" + sum);
        }

        [HttpPost("sub")]
        public IActionResult subtract([FromBody] CalcDto Data)
        {
            int sub = Data.A - Data.B;
            return Ok("subtract =>" + sub);
        }

        [HttpPost("mul")]
        public IActionResult mul([FromBody] CalcDto muldto)
        {
            int mul = muldto.A * muldto.B;
            return Ok("subtract =>" + mul);
        }

    }
}
