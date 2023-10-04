using TestApp.Model;
using TestApp.Service;

namespace TestApp.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IStudentService _studentService;
        private string _selectedYearLevel;

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
                Student.Course = value;
            }
        }
        public string SelectedYearLevel
        {
            get => _selectedYearLevel;
            set
            {
                _selectedYearLevel = value;
                Student.YearLevel = value;
            }
        }
        public RegisterViewModel(IStudentService studentService)
        {
            SelectedSchoolProgram = SelectedCourse = SelectedYearLevel = pickerDefaultValue;
            _studentService = studentService;
            SubmitCommand = new Command(ValidateForm);
            ResetCommand = new Command(ResetForm);
        }

        private void ValidateForm()
        {
            if (!IsFieldEmpty(Student.Id, "Student Id") || !IsFieldEmpty(Student.FirstName, "First Name") || !IsFieldEmpty(Student.LastName, "Last Name") ||
                !IsFieldEmpty(Student.Email, "Email") || !IsFieldEmpty(Student.Password, "Password") || !IsFieldEmpty(Student.ConfirmPassword, "Confirm Password") ||
                !IsFieldEmpty(Student.BirthDate, "Birth Date"))
            {
                return;
            }

            if (!IsMinLength(Student.Id, 5, "Id"))
            {
                return;
            }

            if (!IsDefaultValue(Student.SchoolProgram, "School Program") || !IsDefaultValue(Student.Course, "Course") ||
                !IsDefaultValue(Student.YearLevel, "Year Level"))
            {
                return;
            }
            Register();
        }
        private void Register()
        {
            _studentService.AddStudent(Student);
            Shell.Current.DisplayAlert("Success", "Student successfully registered", "Ok");
            Shell.Current.GoToAsync($"Home?StudentId={Student.Id}");
        }
        private void ResetForm()
        {
            Student.Id = string.Empty;
            Student.FirstName = string.Empty;
            Student.LastName = string.Empty;
            Student.Email = string.Empty;
            Student.MobileNumber = string.Empty;
            Student.Password = string.Empty;
            Student.ConfirmPassword = string.Empty;
            Student.City = string.Empty;
            Student.BirthDate = string.Empty;

            Student.IsMaleCheck = false;
            Student.IsFemaleCheck = false;

            SelectedCourse = SelectedSchoolProgram = SelectedYearLevel = pickerDefaultValue;
        }
    }
}
