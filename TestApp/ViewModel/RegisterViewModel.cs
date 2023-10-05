using System.Collections.ObjectModel;
using TestApp.Model;
using TestApp.Service;
using TestApp.View;


namespace TestApp.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IStudentService _studentService;
        private ObservableCollection<Student> _studentCollection;

        public Student Student { get; set; } = new Student();
        public List<string> YearLevelItemSource { get; set; } = new()
        {
            "--SELECT--",
            "First Year",
            "Second Year",
            "Third Year",
            "Fourth Year",
            "Fifth Year",
        };

        public override string SelectedSchoolProgram
        {
            get => base.SelectedSchoolProgram;
            set
            {
                base.SelectedSchoolProgram = value;
                OnPropertyChanged();
                Student.SchoolProgram = value;
                UpdateCourseItemSource();
            }
        }
        public override string SelectedCourse
        {
            get => base.SelectedCourse;
            set
            {
                base.SelectedCourse = value;
                OnPropertyChanged();
                Student.Course = value;
            }
        }

        private string _selectedYearLevel;
        public string SelectedYearLevel
        {
            get => _selectedYearLevel;
            set
            {
                _selectedYearLevel = value;
                OnPropertyChanged();
                Student.YearLevel = value;
            }
        }

        private bool _isMaleChecked;
        public bool IsMaleChecked
        {
            get => _isMaleChecked;
            set
            {
                _isMaleChecked = value;
                OnPropertyChanged();
                UpdateGender();

            }
        }

        private bool _isFemaleChecked;
        public bool IsFemaleChecked
        {
            get => _isFemaleChecked;
            set
            {
                _isFemaleChecked = value;
                OnPropertyChanged();
                UpdateGender();
            }
        }

        private void UpdateGender()
        {
            if (IsMaleChecked)
            {
                Student.Gender = "Male";
            }
            else
            {
                Student.Gender = "Female";
            }
        }

        public RegisterViewModel(IStudentService studentService)
        {
            SelectedSchoolProgram = SelectedCourse = SelectedYearLevel = pickerDefaultValue;
            _studentService = studentService;
        }

        public override void Register()
        {
            if (ValidateForm())
            {
                _studentService.AddStudent(Student);
                Shell.Current.DisplayAlert("Success", "Student successfully registered", "Ok");
                NavigateBack();
            }
        }

        private bool ValidateForm()
        {
            if (IsFieldEmpty(Student.Id, "Student Id") || IsFieldEmpty(Student.FirstName, "First Name") || IsFieldEmpty(Student.LastName, "Last Name") ||
                IsFieldEmpty(Student.Email, "Email") || IsFieldEmpty(Student.Password, "Password") || IsFieldEmpty(Student.ConfirmPassword, "Confirm Password") ||
                IsFieldEmpty(Student.BirthDate, "Birth Date")) return false;

            if (!IsMinLength(Student.Id, 5, "Id")) return false;

            if (!IsDefaultValue(Student.SchoolProgram, "School Program") || !IsDefaultValue(Student.Course, "Course") ||
                !IsDefaultValue(Student.YearLevel, "Year Level")) return false;

            if (IsStudentIdExisting()) return false;

            if (IsMaleChecked == false && IsFemaleChecked == false) return false;

            return true;
        }

        private bool IsStudentIdExisting()
        {
            _studentCollection = _studentService.GetStudentCollection().Result;
            foreach (var student in _studentCollection)
            {
                if (student.Id == Student.Id)
                {
                    Shell.Current.DisplayAlert("Error", "Student Id already exists", "Ok");
                    return true;
                }
            }
            return false;
        }


        private async void NavigateBack()
        {
            await Shell.Current.GoToAsync($"{nameof(Home)}?id={Student.Id}");
        }

        public override void ResetForm()
        {
            Student.Id = Student.FirstName = Student.LastName = Student.Email = Student.MobileNumber =
                Student.Password = Student.ConfirmPassword = Student.City = Student.BirthDate = string.Empty;


            //reset form by creating a new instance of Student
            //Student = new Student();
            IsMaleChecked = IsFemaleChecked = false;
            SelectedCourse = SelectedSchoolProgram = SelectedYearLevel = pickerDefaultValue;
        }
    }
}
