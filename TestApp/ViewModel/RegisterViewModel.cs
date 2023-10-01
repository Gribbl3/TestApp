using System.Windows.Input;
using TestApp.Model;
using TestApp.Service;

namespace TestApp.ViewModel
{
    public class RegisterViewModel
    {
        private readonly IStudentService _studentService;
        public Student Student { get; set; } = new Student();
        public ICommand SubmitCommand => new Command(ValidateForm);
        public ICommand ResetCommand => new Command(ResetForm);

        public RegisterViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        private void ValidateForm()
        {
            var entries = new[] { Student.Id, Student.FirstName, Student.LastName, Student.Email, Student.Password, Student.ConfirmPassword, Student.BirthDate };
            foreach (var entry in entries)
            {
                if (string.IsNullOrEmpty(entry))
                {
                    // Show error message
                    Shell.Current.DisplayAlert("Error", entry + " is required", "Ok");
                    return;
                }
            }

            if (Student.Id.Length != 5 || !Student.Id.All(char.IsDigit))
            {
                // Show error message
                Shell.Current.DisplayAlert("Error", "ID must be 5 digits", "Ok");
                return;
            }

            if (Student.Password.Length < 8)
            {
                // Show error message
                Shell.Current.DisplayAlert("Error", "Password must be 8 characters", "Ok");
            }

            if (Student.Password != Student.ConfirmPassword)
            {
                // Show error message
                Shell.Current.DisplayAlert("Error", "Password and Confirm Password does not match", "Ok");
                return;
            }

            if (Student.SchoolProgram == Student.SchoolProgramItemSource[0])
            {
                // Show error message
                Shell.Current.DisplayAlert("Error", "School Program is required", "Ok");
                return;
            }

            if (Student.Course == Student.SchoolProgramItemSource[0])
            {
                // Show error message
                Shell.Current.DisplayAlert("Error", "Course is required", "Ok");
                return;
            }


            if (Student.BirthDate == DateTime.Now.ToString("MM/dd/yyyy"))
            {
                // Show error message
                Shell.Current.DisplayAlert("Error", "Birth Date is required", "Ok");
                return;
            }

            if (Student.YearLevel == Student.YearLevelItemSource[0])
            {
                // Show error message
                Shell.Current.DisplayAlert("Error", "Year Level is required", "Ok");
                return;
            }

            if (Student.Course == Student.CourseItemSource[0])
            {
                // Show error message
                Shell.Current.DisplayAlert("Error", "Course is required", "Ok");
                return;
            }

            Register();
        }

        private void Register()
        {
            _studentService.AddStudent(Student);
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

            Student.SchoolProgram = Student.SchoolProgramItemSource[0];
            Student.YearLevel = Student.YearLevelItemSource[0];
            Student.Course = Student.CourseItemSource[0];
        }
    }
}
