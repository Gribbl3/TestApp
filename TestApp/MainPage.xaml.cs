namespace TestApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            Shell.Current.Title = "Window Title";
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            string myText = usernameEntry.Text;
        }

        private void OnEntryCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            string enteredUsername = usernameEntry.Text;
            string enteredPassword = passwordEntry.Text;

            //check if field entered is incorrect 
            bool isAuthenticated = AuthenticateUser(enteredUsername, enteredPassword);

            //check if both or one of the fields is empty
            if (String.IsNullOrEmpty(enteredUsername) || String.IsNullOrEmpty(enteredPassword))
            {
                errMessage.Text = "Username and/or Password should not be empty. Please try again";
                errMessage.TextColor = Colors.Red;
            }
            else if(!isAuthenticated)
            {   
                errMessage.Text = "Username and/or Password is incorrect. Please try again.";
                errMessage.TextColor = Colors.Red;
            }
            else
            {
                errMessage.Text = "Login Successful";
                errMessage.TextColor = Colors.Green;
            }
            
            errMessage.IsVisible = true;

        }

        private bool AuthenticateUser(string username, string password)
        {
            return username == "admin" && password == "admin";
        }
    }
}