namespace DirectoryApp.Pages;
using static System.String;
public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
        //set current theme to light

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
            ResetForm();
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
    }

    private void Reset_Clicked(object sender, EventArgs e)
    {
        txtStudentID.Text = "";
    }
}