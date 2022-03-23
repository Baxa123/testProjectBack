using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proj3.Models;
using Proj3.Services;
using System.Text.Json;

namespace Proj3
{
    public class HomeController : Controller
    {
        PersonService personService = new PersonService();

        [HttpGet]
        public IActionResult GetAll ()
        {
            return Ok(personService.getAll());
        }

       [HttpPut]
        public IActionResult UpdatePerson(int id, [FromBody] Person person) {
            personService.updatePerson(id, person);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            personService.deletePerson(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody]Person person) {
            personService.createUser(person);
            return Ok();
        }

        public IActionResult Index()
        {
            ViewData["text"] = "test";
            return View();
        }

    }
}
