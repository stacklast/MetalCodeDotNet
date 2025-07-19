using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController([FromKeyedServices("peopleService")]IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("alll")]
        public List<People> GetPeople() => Repository.people;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id)
        {
            var people = Repository.people.FirstOrDefault(p => p.Id == id);

            if(people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search) =>
            Repository.people
            .Where(p => p.Name.ToUpper().Contains(search.ToUpper()))
            .ToList();

        [HttpPost]
        public IActionResult Add(People people)
        {
            if(!_peopleService.Validate(people) || people.Name.Length < 100)
            {
                return BadRequest();
            }

            Repository.people.Add(people);

            return NoContent();
        }
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
