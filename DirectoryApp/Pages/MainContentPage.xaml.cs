namespace DirectoryApp.Pages;

public partial class MainContentPage : ContentPage
{
    public MainContentPage()
    {
        InitializeComponent();
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
        else if (!isAuthenticated)
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



    private async void OnLabelTextTapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Register());
    }


}