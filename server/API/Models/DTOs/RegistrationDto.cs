namespace API.Models.DTOs
{
    public class RegistrationDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public int YearsExperience { get; set; }
        public string Title { get; set; }
        public string TechnicalSummary { get; set; }
        public string CurrentEmployer { get; set; }
        public int YearsAtEmployer { get; set; }
        public string JobDescription { get; set; }
    }
}