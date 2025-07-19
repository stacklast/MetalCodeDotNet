using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("async")]
        public IActionResult GetAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Thread.Sleep(1000);
            Console.WriteLine("connexion a base de datos");

            Thread.Sleep(1000);
            Console.WriteLine("Envio de correo");

            Console.WriteLine("Todo ha terminado");

            stopwatch.Stop();

            return Ok(stopwatch.Elapsed);
        }
    }
}
