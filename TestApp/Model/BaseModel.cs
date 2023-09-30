namespace TestApp.Model
{
    //Person class is the base class for Contact and Student classes
    //putting properties that are similar for Contact and Student classes
    public class BaseModel
    {
        public List<string> SchoolProgramItemSource { get; } = new()
        { "-SELECT-",
            "School of Engineering",
            "School of Computer Studies",
            "School of Law",
            "School of Arts and Sciences",
            "School of Business and Management",
            "School of Education",
            "School of Allied Medical Sciences"
        };

        public List<string> CourseItemSource { get; set; } = new();

        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SchoolProgram { get; set; }
        public string Course { get; set; }
        public int? MobileNumber { get; set; }

        //entry accepts a string, if we bind it to an int property it will cause binding error
        //so we need to convert it to int

        //the property that we will be binding to the entry
        public string IdEntry
        {
            get
            {

                if (Id == 0)
                {
                    return string.Empty;
                }
                //when id is null, its to string value is still string.Empty
                return Id.ToString();
            }
            set
            {
                try
                {
                    Id = int.Parse(value);
                }
                catch (Exception)
                {
                    Id = null;
                }
            }
        }

        public string MobileNumberEntry
        {
            get
            {
                if (MobileNumber == 0)
                {
                    return string.Empty;
                }
                return MobileNumber.ToString();
            }
            set
            {
                try
                {
                    MobileNumber = int.Parse(value);
                }
                catch (Exception)
                {
                    MobileNumber = null;
                }
            }
        }
    }
}
