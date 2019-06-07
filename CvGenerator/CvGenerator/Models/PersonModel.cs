namespace CvGenerator.Models
{
    public class PersonModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string School { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }

        public string FullData
        {
            get
            {
                return $"Name: {Name}\n" +
                       $"Surname: {Surname}\n" +
                       $"City: {City}\n" +
                       $"Country: {Country}\n" +
                       $"Phone Number: {PhoneNumber}\n" +
                       $"Email: {Email}\n" +
                       $"Date of brith: {Date}\n" +
                       $"School: {School}\n" +
                       $"Experience:\n {Experience}" +
                       $"Skills:\n {Skills}\n";
            }
        }
    }
}
