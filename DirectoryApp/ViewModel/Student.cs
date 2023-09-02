using System.ComponentModel;

namespace DirectoryApp.ViewModel
{
    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int MobileNumber { get; set; }
        public string City { get; set; }

        public List<string> SchoolProgram { get; set; }

        public List<string> Courses { get; set; }
        public List<string> YearLevel { get; set; }

        public Student()
        {
            //list of school program
            SchoolProgram = new List<string>
            {
                "-SELECT-",
                "School of Engineering",
                "School of Computer Studies"
            };

            //list if school program is School of Engineering
            //Computer Engineering, Electrical Engineering, Electronics Engineering

            //list of courses if school program is School of Computer Studies
            //Computer Science, Information Technology
            Courses = new List<string>();

            //list of year level
            YearLevel = new List<string>
            {
               "",
               "1",
               "2",
               "3",
               "4",
               "5"
            };
        }

    }
}
