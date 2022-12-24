using Microsoft.AspNetCore.Mvc;
using WebApp_Sql_Server.Data.Services;
using WebApp_Sql_Server.Data.ViewModels;

namespace WebApp_Sql_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
       
        private readonly ILogger<PersonController> _logger;
        public PersonService _PersonService { get; set; }

        public PersonController(ILogger<PersonController> logger, PersonService personService)
        {
            _logger = logger;
            _PersonService = personService;
        }

        [HttpPost("add-person")] /*POST*/

        public IActionResult AddPerson([FromBody] PersonVM person)
        {
            _PersonService.AddPerson(person);
            return Ok();
        }

        [HttpPost("edit-person/{personId}")] /*PUT (aktualizacja po id)*/

        public IActionResult EditPersonById(Guid personId, [FromBody]PersonVM person)
        {
            var editPerson = _PersonService.EditPersonById(personId, person);
            return Ok(editPerson);
        }

        [HttpGet("get-person/{personId}")] /*GET (pobranie jednej po id) */
        public IActionResult GetPersonById(Guid personId)
        {
            var onePerson = _PersonService.GetPersonById(personId);
            return Ok(onePerson);
        }

        [HttpDelete("del-person/{personId}")] /* DEL (po id) */

        public IActionResult DelPersonById(Guid personId)
        {
            _PersonService.DeletePersonById(personId);
            return Ok();
        }
    }
}