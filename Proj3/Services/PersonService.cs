using Microsoft.EntityFrameworkCore;
using Proj3.Models;

namespace Proj3.Services
{
    public class PersonService
    {
        public List<Person> getAll() {
            // получение данных
            using (PersonContext db = new PersonContext())
            {
                var users = db.Persons
                    .Include(p => p.PersonalNumbers)
                    .Include(p => p.ServiceNumbers)
                    .Include(p => p.ServiceMobileNumbers)
                    .ToList();
                Console.WriteLine("Список объектов:");
                return users;
            }
        }

        public void updatePerson(int id,Person person) {
            using (PersonContext db = new PersonContext())
            {
                var entity = db.Persons                   
                    .Include(p => p.PersonalNumbers)
                    .Include(p => p.ServiceNumbers)
                    .Include(p => p.ServiceMobileNumbers).SingleOrDefault(p => p.Id == id);
                entity.FirstName=person.FirstName;
                entity.LastName=person.LastName;
                entity.MiddleName = person.MiddleName;
                entity.Position = person.Position;
                entity.StructuralSubdivision=person.StructuralSubdivision;
                entity.ServiceNumbers = person.ServiceNumbers;
                entity.PersonalNumbers = person.PersonalNumbers;
                entity.ServiceMobileNumbers = person.ServiceMobileNumbers;
                db.SaveChanges();
            }
        }

        public void addPerson(Person person)
        {
            using (PersonContext db = new PersonContext())
            {
                db.Persons.Add(person);
                db.SaveChanges();
            }
        }

        public void deletePerson(int id)
        {
            using (PersonContext db = new PersonContext())
            {
                var person = db.Persons.Include(p => p.PersonalNumbers)
                    .Include(p => p.ServiceNumbers)
                    .Include(p => p.ServiceMobileNumbers).SingleOrDefault(p => p.Id == id);
                db.ServiceNumbers.RemoveRange(person.ServiceNumbers);
                db.ServiceNumbers.RemoveRange(person.PersonalNumbers);
                db.ServiceNumbers.RemoveRange(person.ServiceMobileNumbers);
                db.Persons.Remove(person);
                db.SaveChanges();
            }
        }
        public bool createUser(Person person) {
            using (PersonContext db = new PersonContext())
            {
                db.Persons.Add(person);
                db.SaveChanges();
            }
            return true;
        }
      
    }
}
