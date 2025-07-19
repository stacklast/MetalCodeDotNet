using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("alll")]
        public List<People> GetPeople() => Respository.people;
    }

    public class Respository
    {
        public static List<People> people = new List<People>()
        {
            new People()
            {
                Id = 1,
                Name = "Juan",
                BirthDay = new DateTime(1990, 12, 3),
            },
            new People()
            {
                Id = 2,
                Name = "Ana",
                BirthDay = new DateTime(1990, 12, 3),
            },
            new People()
            {
                Id = 3,
                Name = "Luis",
                BirthDay = new DateTime(1990, 12, 3),
            },
            new People()
            {
                Id = 4,
                Name = "Pedro",
                BirthDay = new DateTime(1990, 12, 3),
            },
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
