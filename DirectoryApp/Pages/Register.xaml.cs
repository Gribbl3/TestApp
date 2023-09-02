namespace DirectoryApp.Pages;
using DirectoryApp.ViewModel;
using static System.String;
public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
        //set current theme to light
        Application.Current.UserAppTheme = AppTheme.Dark;
        //set the binding context to the student view model
        BindingContext = new Student();
    }

    private void OnSubmitButtonClick(object sender, EventArgs e)
    {
        bool isValid = ValidateForm(); //call the validate form method

        if (!isValid)
        {
            DisplayAlert("Error", "Please fill in all fields", "OK");
        }
        else
        {
            //call the reset form method

            DisplayAlert("Success", "You have successfully registered", "OK");
        }
    }

    private void OnResetButtonClick(object sender, EventArgs e)
    {
        ResetForm(); //call the reset form method
    }

    private bool ValidateForm()
    {
        //check if all fields are filled
        //check if password and confirm password are the same
        //check if email is valid
        //check if phone number is valid
        //check if username is unique

        if (IsNullOrEmpty(txtStudentID.Text) || IsNullOrEmpty(txtFirstName.Text) ||
            IsNullOrEmpty(txtLastName.Text) || IsNullOrEmpty(txtEmail.Text) ||
            IsNullOrEmpty(txtPassword.Text) || IsNullOrEmpty(txtConfirmPassword.Text) ||
            IsNullOrEmpty(txtMobileNumber.Text))
        {
            return false;
        }
        //else if (Equals(txtPassword.Text, txtConfirmPassword.Text))
        //{
        //    return false;
        //}
        //else
        //{
        //    return true;
        //}
        return true;

    }

    private void ResetForm()
    {
        //call all variables and set them to empty
        txtStudentID.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtEmail.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
        txtMobileNumber.Text = "";
        txtEmail.Text = "";
        pickerSchoolProgram.SelectedIndex = 0;
        pickerCourse.SelectedIndex = 0;
        pickerYearLevel.SelectedIndex = 0;

    }

    private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
    {
        //if (!string.IsNullOrEmpty(txtPassword.Text) && txtPassword.Text.Length < 8)
        //{
        //    // Display an error message or take appropriate action
        //    // You can also disable a button or perform other validation checks here
        //    // For example, you can set an error label's text:
        //    errorLabel.Text = "Enter at least 8 digits";
        //}
        //else
        //{
        //    // Clear the error message if the input is valid
        //    errorLabel.Text = string.Empty;
        //}

        errorLabel.IsVisible = !string.IsNullOrEmpty(errorLabel.Text);
        errorLabel.Text = !string.IsNullOrEmpty(txtPassword.Text) && txtPassword.Text.Length < 8 ? "Enter at least 8 digits" : string.Empty;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Set the default selected item by index
        pickerSchoolProgram.SelectedIndex = 0; // 0 corresponds to "-SELECT-"
        pickerCourse.SelectedIndex = 0;
        pickerYearLevel.SelectedIndex = 0;
    }

}