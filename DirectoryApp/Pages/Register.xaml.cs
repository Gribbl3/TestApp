namespace DirectoryApp.Pages;

using System.Collections.ObjectModel;
using System.ComponentModel;
using static System.String;
public partial class Register : ContentPage, INotifyPropertyChanged
{
    private ObservableCollection<String> _schoolProgram;
    private ObservableCollection<String> _courses;
    private ObservableCollection<String> _yearLevel;

    public ObservableCollection<String> SchoolProgram
    {
        get => _schoolProgram;
        set
        {
            _schoolProgram = value;
            OnPropertyChanged(nameof(SchoolProgram));
        }
    }

    public ObservableCollection<String> Courses
    {
        get => _courses;
        set
        {
            _courses = value;
            OnPropertyChanged(nameof(Courses));
        }
    }

    public ObservableCollection<String> YearLevel
    {
        get => _yearLevel;
        set
        {
            _yearLevel = value;
            OnPropertyChanged(nameof(YearLevel));
        }
    }



    public Register()
    {
        InitializeComponent();
        //set current theme to light
        //set the binding context to the student view model

        //set the school program picker
        SchoolProgram = new ObservableCollection<String>
        {
            "-SELECT-",
            "School of Engineering",
            "School of Computer Studies"
        };

        Courses = new ObservableCollection<String>
        {
            "-SELECT-"
        };

        //set the course picker
        YearLevel = new ObservableCollection<String>
        {
            "-SELECT-",
            "1st Year",
            "2nd Year",
            "3rd Year",
            "4th Year",
            "5th Year"
        };

        BindingContext = this;


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

    private void pickerSchoolProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;


        Courses.Clear();
        if (selectedIndex == 1)
        {
            Courses.Add("BSCE");
            Courses.Add("BSCPE");
            Courses.Add("BSECE");
            Courses.Add("BSIE");
            Courses.Add("BSEE");
            Courses.Add("BSME");
        }
        else if (selectedIndex == 2)
        {
            Courses.Add("BSIT");
            Courses.Add("BSCS");
        }
        else
        {
            Courses.Add("-SELECT-");
        }
    }


}