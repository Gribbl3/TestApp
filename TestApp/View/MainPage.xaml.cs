using System.Collections.ObjectModel;
using System.Windows.Input;
using TestApp.Model;
using TestApp.Service;

namespace TestApp.View
{
    public partial class MainPage : ContentPage
    {
        private string _studentId;
        private ObservableCollection<Student> _studentCollection;
        private readonly IStudentService _studentService;
        public ICommand OnTappedCommand => new Command(OnRegisterTappedCommand);

        public ObservableCollection<Student> StudentCollection
        {
            get { return _studentCollection; }
            set { _studentCollection = value; }
        }
        public MainPage(IStudentService studentService)
        {
            InitializeComponent();

            BindingContext = this;
            Shell.Current.Title = "Window Title";
            _studentService = studentService;
        }
        
        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;
            Shell.Current.Title = "Window Title";
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            string enteredUsername = usernameEntry.Text;
            string enteredPassword = passwordEntry.Text;

            //check if field entered is incorrect 
            bool isAuthenticated = AuthenticateUser(enteredUsername, enteredPassword);
            if (String.IsNullOrEmpty(enteredUsername) || String.IsNullOrEmpty(enteredPassword))
            {
                errMessage.Text = "Username and/or Password should not be empty. Please try again";
                errMessage.TextColor = Colors.Red;
            }
            else if (!isAuthenticated)
            {
                errMessage.Text = "Username and/or Password is incorrect. Please try again.";
                errMessage.TextColor = Colors.Red;
            }
            else
            {
                errMessage.Text = "Login Successful";
                errMessage.TextColor = Colors.Green;
                Shell.Current.GoToAsync($"{nameof(Home)}?id={_studentId}");
            }

            //check if both or one of the fields is empty

            errMessage.IsVisible = true;

        }

        private async void OnRegisterTappedCommand()
        {
            await Shell.Current.GoToAsync(nameof(Register));
        }

        private bool AuthenticateUser(string username, string password)
        {
            foreach (var student in StudentCollection)
            {
                if (student.Id == username && student.Password == password)
                {
                    _studentId = student.Id;
                    return true;
                }
            }
            return false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StudentCollection = _studentService.GetStudentCollection().Result;
        }
    }
}