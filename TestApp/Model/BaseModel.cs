using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestApp.Model
{
    //Person class is the base class for Contact and Student classes
    //putting properties that are similar for Contact and Student classes
    public class BaseModel : INotifyPropertyChanged
    {
        public List<string> SchoolProgramItemSource { get; } = new()
        {
            "--SELECT--",
            "School of Engineering",
            "School of Computer Studies",
            "School of Law",
            "School of Arts and Sciences",
            "School of Business and Management",
            "School of Education",
            "School of Allied Medical Sciences"
        };

        public ObservableCollection<string> CourseItemSource { get; set; } = new();
        private string _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _schoolProgram;
        private string _course;
        private string _mobileNumber;

        public BaseModel()
        {
            SchoolProgram = Course = SchoolProgramItemSource[0];
        }

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string SchoolProgram
        {
            get => _schoolProgram;
            set
            {
                _schoolProgram = value;
                OnPropertyChanged();
                UpdateCourseItemSource();
            }
        }

        public string Course
        {
            get => _course;
            set
            {
                _course = value;
                OnPropertyChanged();
            }
        }

        public string MobileNumber
        {
            get => _mobileNumber;
            set
            {
                _mobileNumber = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateCourseItemSource()
        {
            CourseItemSource.Clear();
            CourseItemSource.Add("--SELECT--");
            switch (SchoolProgram)
            {
                case "School of Engineering":
                    CourseItemSource.Add("Bachelor of Science in Civil Engineering");
                    CourseItemSource.Add("Bachelor of Science in Computer Engineering");
                    CourseItemSource.Add("Bachelor of Science in Electrical Engineering");
                    CourseItemSource.Add("Bachelor of Science in Electronics Engineering");
                    CourseItemSource.Add("Bachelor of Science in Industrial Engineering");
                    CourseItemSource.Add("Bachelor of Science in Mechanical Engineering");
                    break;
                case "School of Computer Studies":
                    CourseItemSource.Add("Bachelor of Science in Computer Science");
                    CourseItemSource.Add("Bachelor of Science in Information Technology");
                    CourseItemSource.Add("Bachelor of Science in Information Systems");
                    break;
                case "School of Law":
                    CourseItemSource.Add("Bachelor of Laws");
                    break;
                case "School of Arts and Sciences":
                    CourseItemSource.Add("Bachelor of Arts in Communication");
                    CourseItemSource.Add("Bachelor of Arts in Marketing Communication");
                    CourseItemSource.Add("Bachelor of Arts in Journalism");
                    CourseItemSource.Add("Bachelor of Arts in English Language Studies");
                    CourseItemSource.Add("Bachelor of Science in Biology major in Medical Biology");
                    CourseItemSource.Add("Bachelor of Science in Biology major in Microbiology");
                    CourseItemSource.Add("Bachelor of Science in Psychology");
                    CourseItemSource.Add("Bachelor of Library and Information Science");
                    CourseItemSource.Add("Bachelor of Arts in International Studies");
                    CourseItemSource.Add("Bachelor of Arts in Political Science");
                    break;
                case "School of Business and Management":
                    CourseItemSource.Add("Bachelor of Science in Accountancy");
                    CourseItemSource.Add("Bachelor of Science in Management Accounting");
                    CourseItemSource.Add("Bachelor of Science in Business Administration  Financial Management");
                    CourseItemSource.Add("Bachelor of Science in Entrepreneurship");
                    CourseItemSource.Add("Bachelor of Science in Business Administration  Operation Management");
                    CourseItemSource.Add("Bachelor of Science in Business Administration  Marketing Management");
                    CourseItemSource.Add("Bachelor of Science in Business Administration  Human Resource Development Management");
                    CourseItemSource.Add("Bachelor of Science in Hospitality Management major in Food and Beverage");
                    CourseItemSource.Add("Bachelor of Science in Tourism Management");
                    break;
                case "School of Education":
                    CourseItemSource.Add("Bachelor of Elementary Education");
                    CourseItemSource.Add("Bachelor of Early Childhood Education");
                    CourseItemSource.Add("Bachelor of Physical Education");
                    CourseItemSource.Add("Bachelor of Secondary Education Major in English");
                    CourseItemSource.Add("Bachelor of Secondary Education Major in Filipino");
                    CourseItemSource.Add("Bachelor of Secondary Education Major in Mathematics");
                    CourseItemSource.Add("Bachelor of Secondary Education Major in Science");
                    CourseItemSource.Add("Bachelor of Special Needs Education-Generalist");
                    CourseItemSource.Add("Bachelor of Special Needs Education major in Early Childhood Education");
                    CourseItemSource.Add("Bachelor of Special Needs Education major in Elementary School Teaching");
                    break;
                case "School of Allied Medical Sciences":
                    CourseItemSource.Add("Bachelor of Science in Nursing");
                    break;
                default:
                    break;
            }
        }
    }
}
