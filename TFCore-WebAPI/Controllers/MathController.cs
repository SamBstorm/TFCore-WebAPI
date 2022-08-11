using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TFCore_WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[Route("mathematique")]
    [ApiController]
    public class MathController : ControllerBase
    {
        [HttpGet]
        public string Welcome()
        {
            return "Bienvenu sur mon API de mathématique!";
        }

        [HttpGet("info")]
        public string Info()
        {
            string message = "Cette application à pour but de vous apprendre les mathématiques à l'aide d'une API codé en .net 6 .";
            return message;
        }

        [HttpGet("Addition")]
        public IActionResult AdditionWithParam(double a = 5, double b = 5) 
        {
            return Addition(a, b);
        }

        [HttpGet("{a}/plus/{b}")]
        public IActionResult Addition(double a = 5, double b = 5)
        {
            return Ok(a + b);
        }
        [HttpGet("Soustraction")]
        public IActionResult Soustraction(double a = 5, double b = 5)
        {
            return Ok(a - b);
        }
        [HttpGet("Multiplication")]
        public IActionResult Multiplication(double a = 5, double b = 5)
        {
            return Ok(a * b);
        }
        [HttpGet("Division")]
        public IActionResult Division(double a = 5, double b = 5)
        {
            try
            {
                if (b == 0) throw new ArgumentException($"Le diviseur ne peut pas être égale à 0, cela tend vers l'infini");
                return Ok(a / b);
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { message = e.Message, a = a, b = b });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
