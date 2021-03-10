namespace BitBoard.Business.Account.Dtos
{
    public class UserDto
    {
        public string UserId { get; set; }
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

    public class UserSkillDto
    {
        public SkillDto Skill { get; set; }

        public int Level { get; set; }
        public int ProgressPercent { get; set; }
    }
}