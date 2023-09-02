using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        private string _selectedSchoolProgram;
        public string SelectedSchoolProgram
        {
            get { return _selectedSchoolProgram; }
            set
            {
                if (_selectedSchoolProgram != value)
                {
                    _selectedSchoolProgram = value;
                    OnPropertyChanged(nameof(SelectedSchoolProgram));

                    // Update the available courses based on the selected school program
                    UpdateCourses();
                }
            }
        }

        private string _selectedCourse;
        public string SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                if (_selectedCourse != value)
                {
                    _selectedCourse = value;
                    OnPropertyChanged();
                }
            }
        }
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
               " ",
               "1",
               "2",
               "3",
               "4",
               "5"
            };
        }

        private void UpdateCourses()
        {
            if (SelectedSchoolProgram == "School of Engineering")
            {
                Courses = new List<string>
                {
                    "-SELECT-",
                    "Computer Engineering",
                    "Electrical Engineering",
                    "Electronics Engineering"
                };
            }
            else if (SelectedSchoolProgram == "School of Computer Studies")
            {
                Courses = new List<string>
                {
                    "-SELECT-",
                    "Computer Science",
                    "Information Technology"
                };
            }
            else
            {
                Courses = new List<string>();


                // Notify property changed for AvailableCourses
                OnPropertyChanged(nameof(Courses));
            }

        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
