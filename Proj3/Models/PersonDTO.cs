namespace Proj3.Models
{
    public class PersonDTO
    {
        public string firstName { get; set; }

        public string middleName { get; set; }

        public string lastName { get; set; }

        public string position { get; set; }

        public string structuralSubdivision { get; set; }

        public List<Telephone> serviceNumbers { get; set; }
        public List<Telephone> personalNumbers { get; set; }
        public List<Telephone> serviceMobileNumbers { get; set; }

    }
}
