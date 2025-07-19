using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("alll")]
        public List<People> GetPeople() => Repository.people;

        [HttpGet("{id}")]
        public People Get(int id) => Repository.people.First(p=>p.Id == id);

        [HttpGet("search/{search}")]
        public List<People> Get(string search) =>
            Repository.people
            .Where(p => p.Name.ToUpper().Contains(search.ToUpper()))
            .ToList();
    }

    public class Repository
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
