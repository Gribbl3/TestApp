using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestApp.Model
{
    //Person class is the base class for Contact and Student classes
    //putting properties that are similar for Contact and Student classes
    public class BaseModel : INotifyPropertyChanged
    {
        #region Properties
        private string _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _schoolProgram;
        private string _course;
        private string _mobileNumber;

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public string SchoolProgram
        {
            get => _schoolProgram;
            set
            {
                _schoolProgram = value;
                OnPropertyChanged();
            }
        }
        public string Course
        {
            get => _course;
            set
            {
                _course = value;
                OnPropertyChanged();
            }
        }
        public string MobileNumber
        {
            get => _mobileNumber;
            set
            {
                _mobileNumber = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion 
    }
}
