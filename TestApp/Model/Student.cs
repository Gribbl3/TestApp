namespace TestApp.Model
{
    public class Student : BaseModel
    {
        public List<string> YearLevelItemSource { get; set; } = new()
        {
            "--SELECT--",
            "First Year",
            "Second Year",
            "Third Year",
            "Fourth Year",
            "Fifth Year",
        };

        public Student()
        {
            YearLevel = YearLevelItemSource[0];
        }
        public string Gender => IsMaleCheck ? "Male" : "Female";
        private string _password;
        private string _confirmPassword;
        private string _yearLevel;
        private string _birthDate;
        private string _city;
        private bool _isMaleCheck;
        private bool _isFemaleCheck;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }

        public string YearLevel
        {
            get => _yearLevel;
            set
            {
                _yearLevel = value;
                OnPropertyChanged();
            }
        }

        public string BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }

        public bool IsMaleCheck
        {
            get => _isMaleCheck;
            set
            {
                _isMaleCheck = value;
                OnPropertyChanged();
            }
        }

        public bool IsFemaleCheck
        {
            get => _isFemaleCheck;
            set
            {
                _isFemaleCheck = value;
                OnPropertyChanged();
            }
        }
    }
}
