using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult Getsync()
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

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("connexion a base de datos");

                return 1;
            });

            var task2 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envio de correo");

                return 2;
            });

            task1.Start();
            task2.Start();

            Console.WriteLine("hago otra cosa");

            var result = await task1;
            var result2 = await task2;

            Console.WriteLine("Todo ha terminado");

            return Ok(result + " " + result2 + " " + stopwatch.Elapsed);
        }
    }
}
