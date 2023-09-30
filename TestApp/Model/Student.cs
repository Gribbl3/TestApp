namespace TestApp.Model
{
    public class Student : BaseModel
    {

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Gender => IsMaleCheck ? "Male" : "Female";
        public string YearLevel { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public bool IsMaleCheck { get; set; }
        public bool IsFemaleCheck { get; set; }
        public List<string> YearLevelItemSource { get; set; } = new()
        {
            "First Year",
            "Second Year",
            "Third Year",
            "Fourth Year",
            "Fifth Year",
        };
    }


}
