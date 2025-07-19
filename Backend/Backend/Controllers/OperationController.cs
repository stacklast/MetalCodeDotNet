using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Get(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpPost]
        public decimal Add(decimal a, decimal b, 
            [FromHeader] string Host, 
            [FromHeader(Name = "Content-Lenght")] string ContentLength)
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLength);
            return a + b;
        }

        [HttpPut]
        public decimal Edit(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpDelete]
        public decimal Delete(decimal a, decimal b)
        {
            return a + b;
        }
    }
}
