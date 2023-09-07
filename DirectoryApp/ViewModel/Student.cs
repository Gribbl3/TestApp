//using System.ComponentModel;
//using System.Runtime.CompilerServices;

//namespace DirectoryApp.ViewModel
//{
//    public class Student : INotifyPropertyChanged
//    {
//        public event PropertyChangedEventHandler PropertyChanged;

//        private List<string> _schoolProgram;
//        private List<string> _courses;
//        private List<string> _yearLevel;
//        private string _selectedSchoolProgram; //selected school program on picker xaml property 
//        private string _selectedCourse;        //selected course on picker xaml property

//        public List<string> SchoolProgram
//        {
//            get => _schoolProgram;
//            set
//            {
//                _schoolProgram = value;
//                OnPropertyChanged(nameof(_schoolProgram));
//            }
//        }

//        public List<string> Courses
//        {
//            get => _courses;
//            set
//            {
//                _courses = value;
//                OnPropertyChanged(nameof(_courses));
//            }
//        }

//        public List<string> YearLevel
//        {
//            get => _yearLevel;
//            set
//            {
//                _yearLevel = value;
//                OnPropertyChanged(nameof(_yearLevel));
//            }
//        }

//        public string SelectedSchoolProgram
//        {
//            get => _selectedSchoolProgram;
//            set
//            {
//                _selectedSchoolProgram = value;
//                OnPropertyChanged(nameof(_selectedCourse));
//                UpdateCourses();
//            }
//        }

//        public string SelectedCourse
//        {
//            get => _selectedCourse;
//            set
//            {
//                _selectedCourse = value;
//                OnPropertyChanged();
//            }
//        }

//        public Student()
//        {
//            _schoolProgram = new List<string>
//            {
//                "-SELECT-",
//                "School of Engineering",
//                "School of Computer Science"
//            };

//            _courses = new List<string>
//            {
//                "-SELECT-"
//            };
//            _yearLevel = new List<string>
//            {
//                "1",
//                "2",
//                "3",
//                "4",
//                "5"
//            };
//        }



//        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }

//        private void UpdateCourses()
//        {
//            Courses.Clear();
//            if (_selectedSchoolProgram == "School of Engineering")
//            {
//                Courses.Add("BS Civil Engineering");
//                Courses.Add("BS Computer Engineering");
//                Courses.Add("BS Electrical Engineering");
//                Courses.Add("BS Electronics Engineering");
//                Courses.Add("BS Industrial Engineering");
//                Courses.Add("BS Mechanical Engineering");

//            }

//            else if (_selectedSchoolProgram == "School of Computer Science")
//            {
//                Courses.Add("BS Computer Science");
//                Courses.Add("BS Information Technology");
//                Courses.Add("BS Information Systems");
//            }

//            else
//            {
//                Courses.Add("-SELECT-");

//            };

//        }
//    }
//}
