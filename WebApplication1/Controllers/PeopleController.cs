using System.Collections.Generic;
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
        public async Task AddPerson(Person personDto)
        {
            var person = new Person()
            {
                FirstName = personDto.FirstName,
                LastName = personDto.LastName
            };

            await _peopleRepository.InsertOneAsync(person);
        }

        [HttpGet]
        public IEnumerable<string> Get(string lastName)
        {
            var people = _peopleRepository.FilterBy(
                filter => filter.FirstName == lastName,
                projection => projection.FirstName
            );
            return people;
        }
    }
}