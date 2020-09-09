using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IMongoRepository<Person> _peopleRepository;

        public PeopleController(IMongoRepository<Person> peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpPost]
        public async Task AddPerson(Person person)
        {
            await _peopleRepository.InsertOneAsync(person);

            var x = await _peopleRepository.FindByIdAsync(person.Id);
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get(string lastName)
        {
            //var people = _peopleRepository.FilterBy(
            //    filter => filter.FirstName == lastName,
            //    projection => projection.FirstName
            //);

            var x = await _peopleRepository.FindByIdAsync(new System.Guid("bd619420-3ce3-4a49-a89c-b67320730cbd"));

            var people = _peopleRepository.AsQueryable().ToList();

            return people;
        }
    }
}