using System.Collections.ObjectModel;
using System.Windows.Input;
using TestApp.Model;
using TestApp.Service;
using TestApp.View;

namespace TestApp.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Fields and Properties
        private readonly IStudentService _studentService;
        private bool _isErrorVisible;
        private string _errorMessage;
        private string _studentId;
        private string _password;
        private ObservableCollection<Student> _studentCollection;

        public bool IsErrorVisible
        {
            get => _isErrorVisible;
            set
            {
                _isErrorVisible = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public string StudentId
        {
            get => _studentId;
            set
            {
                _studentId = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand OnTappedCommand => new Command(OnRegisterTappedCommand);
        public ICommand OnButtonClickedCommand => new Command(OnButtonClicked);
        #endregion

        //constructor
        public MainPageViewModel(IStudentService studentService)
        {
            _studentService = studentService;
            _studentCollection = _studentService.GetStudentCollection().Result;
        }

        #region Methods
        private async void OnRegisterTappedCommand()
        {
            await Shell.Current.GoToAsync(nameof(Register));
        }

        private bool AuthenticateUser()
        {
            foreach (var student in _studentCollection)
            {
                if (student.Id == StudentId && student.Password == Password)
                {
                    return true;
                }
            }
            return false;
        }

        private void OnButtonClicked()
        {
            bool isAuthenticated = AuthenticateUser();
            if (String.IsNullOrEmpty(StudentId) || String.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Username and/or Password should not be empty. Please try again";
            }
            else if (!isAuthenticated)
            {
                ErrorMessage = "Username and/or Password is incorrect. Please try again.";
            }
            else
            {
                ErrorMessage = "Login Successful";
                Shell.Current.GoToAsync($"{nameof(Home)}?id={StudentId}");
            }
            IsErrorVisible = true;
        }
        #endregion
    }
}
