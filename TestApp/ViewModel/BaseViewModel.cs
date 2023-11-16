using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TestApp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly string pickerDefaultValue = "--SELECT--";

        public virtual string SelectedSchoolProgram { get; set; }
        public virtual string SelectedCourse { get; set; }
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

        //update course item source based on selected school program
        public void UpdateCourseItemSource()
        {
            CourseItemSource.Clear();
            switch (SelectedSchoolProgram)
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
                    CourseItemSource.Add(pickerDefaultValue);
                    break;
            }
        }
        #region Commands for student and contact views
        public ICommand SubmitCommand => new Command(Register);
        public virtual void Register()
        {
            throw new NotImplementedException();
        }

        public ICommand ResetCommand => new Command(ResetForm);
        public virtual void ResetForm()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Validation
        //entries validation
        protected bool IsFieldEmpty(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(value))
            {
                Shell.Current.DisplayAlert("Error", $"{fieldName} is required", "Ok");
                return true;
            }
            return false;
        }
        //id and password validation
        protected bool IsMinLength(string value, int minLength, string fieldName)
        {
            if (value.Length < minLength)
            {
                Shell.Current.DisplayAlert("Error", $"{fieldName} must be at least {minLength} characters", "Ok");
                return false;
            }
            return true;
        }
        //pickers validation
        protected bool IsDefaultValue(string value, string fieldName)
        {
            if (value == pickerDefaultValue || value == null)
            {
                Shell.Current.DisplayAlert("Error", $"{fieldName} is required", "Ok");
                return false;
            }
            return true;
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
