namespace Proj3.Models
{
    public class Person
    {
        public int? Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public string StructuralSubdivision { get; set; }

        public List<Telephone> ServiceNumbers { get; set; }
        public List<Telephone> PersonalNumbers { get; set; }
        public List<Telephone> ServiceMobileNumbers { get; set; }

        public Person()
        {
        }

        public Person(int? id, string firstName, string middleName, string lastName, string position, string structuralSubdivision, List<Telephone> serviceNumbers, List<Telephone> personalNumbers, List<Telephone> serviceMobileNumbers)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Position = position;
            StructuralSubdivision = structuralSubdivision;
            ServiceNumbers = serviceNumbers;
            PersonalNumbers = personalNumbers;
            ServiceMobileNumbers = serviceMobileNumbers;
        }
    }
}
