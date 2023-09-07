namespace DirectoryApp.Pages;

using CommunityToolkit.Maui.Views;
using DirectoryApp.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using static System.String;


public partial class Register : ContentPage, INotifyPropertyChanged
{
    //implement the INotifyPropertyChanged interface



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

        //omit the navigation bar 
        NavigationPage.SetHasNavigationBar(this, false);

        //initialize the back button title
        NavigationPage.SetBackButtonTitle(this, "Back");


        //initialize the school program picker
        SchoolProgram = new ObservableCollection<String>
        {
            "-SELECT-",
            "School of Engineering",
            "School of Computer Studies"
        };

        //initialize the course picker
        Courses = new ObservableCollection<String>
        {
            "-SELECT-"
        };

        //initialize the year level picker
        YearLevel = new ObservableCollection<String>
        {
            "-SELECT-",
            "1st Year",
            "2nd Year",
            "3rd Year",
            "4th Year",
            "5th Year"
        };

        //set the binding context
        BindingContext = this;

        //borderStudentID.SetBinding(Border.StrokeProperty, new Binding("IsValid", source: validationBehaviorStudentID));

    }

    private void OnSubmitButtonClick(object sender, EventArgs e)
    {
        //bool isValid = ValidateForm(); //call the validate form method

        //if (!isValid)
        //{
        //    DisplayAlert("Error", "Please fill in all fields", "OK");
        //}
        //else
        //{
        //    call the reset form method

        //    DisplayAlert("Success", "You have successfully registered", "OK");
        //}

        //call newcontent1 page as popup 

        var popup = new NewContent1(RegisterUser());

        this.ShowPopup(popup);
    }

    private Student RegisterUser()
    {
        Student theStudent = new Student();
        theStudent.StudentID = int.Parse(txtStudentID.Text);
        theStudent.FirstName = txtFirstName.Text;
        theStudent.LastName = txtLastName.Text;
        theStudent.Email = txtEmail.Text;
        theStudent.Password = txtPassword.Text;
        theStudent.ConfirmPassword = txtConfirmPassword.Text;
        theStudent.Gender = rdoMale.IsChecked ? "Male" : "Female";
        theStudent.MobileNumber = (int)long.Parse(txtMobileNumber.Text);
        theStudent.City = txtCity.Text;
        theStudent.SchoolProgram = pickerSchoolProgram.SelectedItem.ToString();
        theStudent.Course = pickerCourse.SelectedItem.ToString();
        theStudent.YearLevel = pickerYearLevel.SelectedItem.ToString();
        theStudent.BirthDate = dateBirthDate.Date;

        return theStudent;
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
            IsNullOrEmpty(txtMobileNumber.Text) ||
            IsNullOrEmpty(txtMobileNumber.Text) || (!rdoFemale.IsChecked) && (!rdoMale.IsChecked))
        {
            return false;
        }

        if (!Equals(txtPassword.Text, txtConfirmPassword.Text))
        {
            return false;
        }

        return true;


    }

    private void ResetForm()
    {
        //call all variables and set them to empty
        //txtStudentID.Text = "";
        //txtFirstName.Text = "";
        //txtLastName.Text = "";
        //txtEmail.Text = "";
        //txtPassword.Text = "";
        //txtConfirmPassword.Text = "";
        //txtMobileNumber.Text = "";
        //txtEmail.Text = "";
        //rdoMale.IsChecked = false;
        //rdoFemale.IsChecked = false;
        //pickerSchoolProgram.SelectedIndex = 0;
        //pickerCourse.SelectedIndex = 0;
        //pickerYearLevel.SelectedIndex = 0;
        Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault(new Register());
        Application.Current.MainPage.Navigation.PushAsync(new Register(), false);
        Application.Current.MainPage.Navigation.RemovePage(this);

    }



    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Set the default selected item index by 0
        //-1 corresponds to "No Selection", so we don't want that
        pickerSchoolProgram.SelectedIndex = 0; // 0 corresponds to "-SELECT-"
        pickerCourse.SelectedIndex = 0;
        pickerYearLevel.SelectedIndex = 0;
    }

    private void pickerSchoolProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        //set the course picker items based on the selected school program

        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        //clear the courses picker
        Courses.Clear();

        //add the courses based on the selected school program

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