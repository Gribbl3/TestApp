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

        private string _selectedYearLevel;
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
            SubmitCommand = new Command(ValidateForm);
            ResetCommand = new Command(ResetForm);

            SelectedSchoolProgram = SelectedCourse = SelectedYearLevel = pickerDefaultValue;
            _studentService = studentService;
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

            if (IsStudentIdExisting())
            {
                return;
            }

            Register();
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

        private void Register()
        {
            _studentService.AddStudent(Student);
            Shell.Current.DisplayAlert("Success", "Student successfully registered", "Ok");
            NavigateBack();
        }

        private async void NavigateBack()
        {
            await Shell.Current.GoToAsync($"{nameof(Home)}?StudentId={Student.Id}");
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

            //reset form by creating a new instance of Student
            //Student = new Student();

            SelectedCourse = SelectedSchoolProgram = SelectedYearLevel = pickerDefaultValue;
        }
    }
}
