namespace TestApp.Model
{
    public class Student : BaseModel
    {

        private string _password;
        private string _confirmPassword;
        private string _yearLevel;
        private string _birthDate;
        private string _city;
        private string _gender;
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
                //convert to yyyy-MM-dd format
                if (DateTime.TryParse(value, out DateTime parsedDate))
                {
                    _birthDate = parsedDate.ToString("yyyy-MM-dd");
                    return;
                }
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

        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }
    }
}
