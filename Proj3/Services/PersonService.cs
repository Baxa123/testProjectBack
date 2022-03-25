using Microsoft.EntityFrameworkCore;
using Proj3.Models;

namespace Proj3.Services
{
    public class PersonService
    {
        public List<Person> getAll() {
            using (PersonContext db = new PersonContext())
            {
                var users = db.Persons
                    .Include(p => p.PersonalNumbers)
                    .Include(p => p.ServiceNumbers)
                    .Include(p => p.ServiceMobileNumbers)
                    .ToList();
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

        internal List<Person> getSelectedStructuralSubdivision(string selectedStructuralSubdivision)
        {
            using (PersonContext db = new PersonContext())
            {
               return db.Persons.Include(p => p.PersonalNumbers)
                        .Include(p => p.ServiceNumbers)
                        .Include(p => p.ServiceMobileNumbers).Where(p => p.StructuralSubdivision == selectedStructuralSubdivision).ToList();
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

        public void deletePerson(int[] selectedPersons)
        {
            using (PersonContext db = new PersonContext())
            {
                for (int i = 0; i < selectedPersons.Length; i++)
                {
                    var person = db.Persons.Include(p => p.PersonalNumbers)
                        .Include(p => p.ServiceNumbers)
                        .Include(p => p.ServiceMobileNumbers).SingleOrDefault(p => p.Id == selectedPersons[i]);
                    if (person != null)
                    {
                        db.ServiceNumbers.RemoveRange(person.ServiceNumbers);
                        db.ServiceNumbers.RemoveRange(person.PersonalNumbers);
                        db.ServiceNumbers.RemoveRange(person.ServiceMobileNumbers);
                        db.Persons.Remove(person);
                        db.SaveChanges();
                    }
                }
            }
        }
        public bool createUser(Person person) {
            using (PersonContext db = new PersonContext())
            {
                person.Id = null;
                db.Persons.Add(person);
                db.SaveChanges();
            }
            return true;
        }
      
    }
}
