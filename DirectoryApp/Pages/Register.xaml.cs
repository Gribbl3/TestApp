namespace DirectoryApp.Pages;

using CommunityToolkit.Maui.Views;
using DirectoryApp.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

//things to do
//figure out how to target all pickers selectedIndexChanged event

public partial class Register : ContentPage, INotifyPropertyChanged
{
    //implement the INotifyPropertyChanged interface

    public DateTime MaxDate { get; set; } = DateTime.Today;
    public DateTime MinimumDate { get; set; } = DateTime.Today.AddYears(-200);

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
            "School of Computer Studies",
            "School of Law",
            "School of Arts and Sciences",
            "School of Business and Management",
            "School of Education",
            "School of Allied Medical Sciences"
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

        dateBirthDate.DateSelected += OnDateSelected;
        //set the binding context
        BindingContext = this;

        //borderStudentID.SetBinding(Border.StrokeProperty, new Binding("IsValid", source: validationBehaviorStudentID));

    }

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        //set the date label to the selected date
        DateTime selectedDate = e.NewDate;

        if (selectedDate == DateTime.Today)
        {
            borderDatePicker.Stroke = Colors.Red;
            imgDatePicker.Source = "x_mark.png";
        }
        else
        {
            imgDatePicker.Source = "check.png";
        }
    }

    private void OnSubmitButtonClick(object sender, EventArgs e)
    {

        if (!ValidateForm())
        {
            DisplayAlert("Error", "Please fill in all fields and ensure that the passwords match.", "OK");
            return;
        }

        //call newcontent1 page as popup 

        var popup = new RegisterPopup(RegisterUser());

        this.ShowPopup(popup);
    }

    private Student RegisterUser()
    {
        return new Student
        {
            StudentID = int.Parse(txtStudentID.Text),
            FirstName = txtFirstName.Text,
            LastName = txtLastName.Text,
            Email = txtEmail.Text,
            Password = txtPassword.Text,
            ConfirmPassword = txtConfirmPassword.Text,
            Gender = rdoMale.IsChecked ? "Male" : "Female",
            BirthDate = dateBirthDate.Date.ToString("dd/MM/yyyy"),
            MobileNumber = txtMobileNumber.Text,
            City = txtCity.Text,
            SchoolProgram = pickerSchoolProgram.SelectedItem.ToString(),
            Course = pickerCourse.SelectedItem.ToString(),
            YearLevel = pickerYearLevel.SelectedItem.ToString(),
        };
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

        //used the validateBehaviors

        bool areAllFieldsValid =
                validateBehaviorStudentID.IsValid &&
                validateBehaviorFirstName.IsValid &&
                validateBehaviorLastName.IsValid &&
                validateBehaviorEmail.IsValid &&
                validateBehaviorPassword.IsValid &&
                validateBehaviorMatchPassword.IsValid &&
                validateBehaviorMobileNumber.IsValid &&
                (pickerSchoolProgram.SelectedIndex != 0) &&
                (pickerCourse.SelectedIndex != 0) &&
                (pickerYearLevel.SelectedIndex != 0) &&
                (rdoFemale.IsChecked || rdoMale.IsChecked) &&
                dateBirthDate.Date != DateTime.Today;

        bool arePasswordsMatching = txtPassword.Text == txtConfirmPassword.Text;

        return areAllFieldsValid && arePasswordsMatching;

    }

    private async void ResetForm()
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

        //refactored
        //Entry[] entries = { txtStudentID, txtFirstName, txtLastName, txtEmail, txtPassword, txtConfirmPassword, txtMobileNumber, txtCity };
        //foreach (var entry in entries)
        //{
        //    entry.Text = string.Empty;
        //}

        //rdoFemale.IsChecked = false;
        //rdoMale.IsChecked = false;

        //dateBirthDate.Date = DateTime.Today;

        //pickerSchoolProgram.SelectedIndex = 0;
        //pickerCourse.SelectedIndex = 0;
        //pickerYearLevel.SelectedIndex = 0;

        Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault(new Register());
        await Application.Current.MainPage.Navigation.PushAsync(new Register(), false);
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

        imgDatePicker.Source = "x_mark.png";
        imgConfirmPassword.Source = "x_mark.png";

        txtStudentID.Text = string.Empty;
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtPassword.Text = string.Empty;
        txtConfirmPassword.Text = string.Empty;
        txtMobileNumber.Text = string.Empty;
        txtCity.Text = string.Empty;

    }

    private void pickerSchoolProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        //set the course picker items based on the selected school program

        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex == 0)
        {
            borderSchoolProgram.Stroke = Colors.Red;
            imgPickerSchoolProgram.Source = "x_mark.png";
        }
        else
        {
            borderSchoolProgram.Stroke = Colors.Black;
            imgPickerSchoolProgram.Source = "check.png";
        }
        //clear the courses picker
        Courses.Clear();
        Courses.Add("-SELECT-");
        //add the courses based on the selected school program

        //"School of Engineering", 1
        if (selectedIndex == 1)
        {
            Courses.Add("Bachelor of Science in Civil Engineering");
            Courses.Add("Bachelor of Science in Computer Engineering");
            Courses.Add("Bachelor of Science in Electrical Engineering");
            Courses.Add("Bachelor of Science in Electronics Engineering");
            Courses.Add("Bachelor of Science in Industrial Engineering");
            Courses.Add("Bachelor of Science in Mechanical Engineering");
        }
        //"School of Computer Studies", 2
        else if (selectedIndex == 2)
        {
            Courses.Add("Bachelor of Science in Computer Science");
            Courses.Add("Bachelor of Science in Information Technology");
            Courses.Add("Bachelor of Science in Information Systems");
        }
        //"School of Law", 3
        else if (selectedIndex == 3)
        {
            Courses.Add("Bachelor of Laws");
        }
        //"School of Arts and Sciences",4
        else if (selectedIndex == 4)
        {
            Courses.Add("Bachelor of Arts in Communication");
            Courses.Add("Bachelor of Arts in Marketing Communication");
            Courses.Add("Bachelor of Arts in Journalism");
            Courses.Add("Bachelor of Arts in English Language Studies");
            Courses.Add("Bachelor of Science in Biology major in Medical Biology");
            Courses.Add("Bachelor of Science in Biology major in Microbiology");
            Courses.Add("Bachelor of Science in Psychology");
            Courses.Add("Bachelor of Library and Information Science");
            Courses.Add("Bachelor of Arts in International Studies");
            Courses.Add("Bachelor of Arts in Political Science");
        }
        //"School of Business and Management",5
        else if (selectedIndex == 5)
        {
            Courses.Add("Bachelor of Science in Accountancy");
            Courses.Add("Bachelor of Science in Management Accounting");
            Courses.Add("Bachelor of Science in Business Administration – Financial Management");
            Courses.Add("Bachelor of Science in Entrepreneurship");
            Courses.Add("Bachelor of Science in Business Administration – Operation Management");
            Courses.Add("Bachelor of Science in Business Administration – Marketing Management");
            Courses.Add("Bachelor of Science in Business Administration – Human Resource Development Management");
            Courses.Add("Bachelor of Science in Hospitality Management major in Food and Beverage");
            Courses.Add("Bachelor of Science in Tourism Management");

        }
        //"School of Education", 6
        else if (selectedIndex == 6)
        {
            Courses.Add("Bachelor of Elementary Education");
            Courses.Add("Bachelor of Early Childhood Education");
            Courses.Add("Bachelor of Physical Education");
            Courses.Add("Bachelor of Secondary Education Major in English");
            Courses.Add("Bachelor of Secondary Education Major in Filipino");
            Courses.Add("Bachelor of Secondary Education Major in Mathematics");
            Courses.Add("Bachelor of Secondary Education Major in Science");
            Courses.Add("Bachelor of Special Needs Education-Generalist");
            Courses.Add("Bachelor of Special Needs Education major in Early Childhood Education");
            Courses.Add("Bachelor of Special Needs Education major in Elementary School Teaching");
        }
        //"School of Allied Medical Sciences" 7
        else if (selectedIndex == 7)
        {
            Courses.Add("Bachelor of Science in Nursing");
        }
        else
        {
            return;
        }


        //di ko kabalo mo refactor ani huhu

    }

    private void txtConfirmPassword_TextChanged(object sender, FocusEventArgs e)
    {
        lblPasswordNotMatch.IsVisible = txtPassword.Text != txtConfirmPassword.Text;

    }


    private void pickerYearLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex == 0)
        {
            borderYearLevel.Stroke = Colors.Red;
            imgPickerYearLevel.Source = "x_mark.png";
        }
        else
        {
            borderYearLevel.Stroke = Colors.Black;
            imgPickerYearLevel.Source = "check.png";
        }
    }



    private void pickerCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex == 0 || selectedIndex == -1)
        {
            borderCourse.Stroke = Colors.Red;
            imgPickerCourse.Source = "x_mark.png";
        }
        else
        {
            borderCourse.Stroke = Colors.Black;
            imgPickerCourse.Source = "check.png";
        }
    }

    //args is the event arguments
    //sender is the object that raised the event


}