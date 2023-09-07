using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DirectoryApp.ViewModel
{
    public class Student : INotifyPropertyChanged
    {

        private int _studentID;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private string _gender;
        private DateTime _birthDate;
        private int _mobileNumber;
        private string _city;
        private string _schoolProgram;
        private string _course;
        private string _yearLevel;

        public event PropertyChangedEventHandler PropertyChanged;
        public int StudentID
        {
            get => _studentID;
            set
            {
                _studentID = value;
                OnPropertyChanged(nameof(StudentID));
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        public int MobileNumber
        {
            get => _mobileNumber;
            set
            {
                _mobileNumber = value;
                OnPropertyChanged(nameof(MobileNumber));
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }


        public string SchoolProgram
        {
            get => _schoolProgram;
            set
            {
                _schoolProgram = value;
                OnPropertyChanged(nameof(SchoolProgram));
            }
        }

        public string Course
        {
            get => _course;
            set
            {
                _course = value;
                OnPropertyChanged(nameof(Course));
            }
        }

        public string YearLevel
        {
            get => _yearLevel;
            set
            {
                _yearLevel = value;
                OnPropertyChanged(nameof(YearLevel));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
