using System.Collections.ObjectModel;
using TestApp.Service;
using Contact = TestApp.Model.Contact;
namespace TestApp.ViewModel
{
    [QueryProperty(nameof(StudentId), "id")]
    public class AddContactViewModel : BaseViewModel
    {
        private readonly IContactService _contactsService;
        public Contact Contact { get; set; } = new Contact();

        private string _studentId;
        public string StudentId
        {
            get { return _studentId; }
            set
            {
                _studentId = value;
                OnPropertyChanged();
                LoadContacts();
            }
        }

        private ObservableCollection<Contact> _contactCollection;
        public ObservableCollection<Contact> ContactCollection
        {
            get { return _contactCollection; }
            set
            {
                _contactCollection = value;
                //observable collection is inheriting INotifyProperChanged but the OnPropertyChanged is not yet invoke.
                //we need to listen (event handlers) for the changes.
                OnPropertyChanged();
            }
        }

        private bool _isFaculty;
        public bool IsFaculty
        {
            get { return _isFaculty; }
            set
            {
                _isFaculty = value;
                OnPropertyChanged();
                UpdateType();
            }
        }

        private bool _isStudent;
        public bool IsStudent
        {
            get { return _isStudent; }
            set
            {
                _isStudent = value;
                OnPropertyChanged();
                UpdateType();
            }
        }

        private void UpdateType()
        {
            if (IsFaculty)
            {
                Contact.Type = "Faculty";
            }
            else
            {
                Contact.Type = "Student";
            }
        }

        public AddContactViewModel(IContactService contactsService)
        {
            _contactsService = contactsService;
        }
        public override string SelectedSchoolProgram
        {
            get => base.SelectedSchoolProgram;
            set
            {
                base.SelectedSchoolProgram = value;
                Contact.SchoolProgram = value;
                UpdateCourseItemSource();
            }
        }
        public override string SelectedCourse
        {
            get => base.SelectedCourse;
            set
            {
                base.SelectedCourse = value;
                Contact.Course = value;
            }
        }
        public override void Register()
        {
            if (ValidateForm())
            {
                _contactsService.AddContact(Contact, StudentId);
                Shell.Current.DisplayAlert("Success", "Contact added successfully", "Ok");
                NavigateBack();
            }
        }
        private async void NavigateBack()
        {
            await Shell.Current.GoToAsync($"..?id={StudentId}");
        }
        private bool ValidateForm()
        {
            if (IsFieldEmpty(Contact.Id, "Contact Id") || IsFieldEmpty(Contact.FirstName, "First Name") ||
                IsFieldEmpty(Contact.LastName, "Last Name") || IsFieldEmpty(Contact.Email, "Email"))
            {
                return false;
            }

            if (!IsMinLength((Contact.Id), 5, "Id"))
            {
                return false;
            }

            if (!IsDefaultValue(Contact.SchoolProgram, "School Program") || !IsDefaultValue(Contact.Course, "Course"))
            {
                return false;
            }

            if (IsStudentIdExisting())
            {
                return false;
            }

            return true;
        }

        public override void ResetForm()
        {
            Contact.Id = Contact.FirstName = Contact.LastName = Contact.Email = Contact.MobileNumber = string.Empty;
            IsFaculty = IsStudent = false;
            SelectedSchoolProgram = SelectedCourse = pickerDefaultValue;
        }

        private void LoadContacts()
        {
            if (StudentId != null)
            {
                ContactCollection = _contactsService.GetContacts(_studentId).Result;
            }
        }

        private bool IsStudentIdExisting()
        {
            _contactCollection = _contactsService.GetContacts(StudentId).Result;
            foreach (var contact in _contactCollection)
            {
                if (contact.Id == Contact.Id)
                {
                    Shell.Current.DisplayAlert("Error", "Contact Id already exists", "Ok");
                    return true;
                }
            }
            return false;
        }
    }
}
