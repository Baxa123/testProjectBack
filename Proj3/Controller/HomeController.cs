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

        [HttpGet]
        public IActionResult ChangeStructuralSubdivision(string selectedStructuralSubdivision) {
            if (selectedStructuralSubdivision == "-1")
            {
                return GetAll();
            }
            return Ok(personService.getSelectedStructuralSubdivision(selectedStructuralSubdivision));
        }

       [HttpPut]
        public IActionResult UpdatePerson(int id, [FromBody] Person person) {
            personService.updatePerson(id, person);
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete([FromBody]int[] selectedPersons)
        {
            personService.deletePerson(selectedPersons);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody]Person person) {
            personService.createUser(person);
            return Ok();
        }
    }
}
