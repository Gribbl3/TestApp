using System.Collections.ObjectModel;
using TestApp.Service;
using Contact = TestApp.Model.Contact;
namespace TestApp.ViewModel
{
    [QueryProperty(nameof(ContactCollection), "contacts")]
    [QueryProperty(nameof(StudentId), "id")]
    public class AddContactViewModel : BaseViewModel
    {
        private readonly IContactService _contactService;
        public Contact Contact { get; set; } = new Contact();

        private string _studentId;
        public string StudentId
        {
            get { return _studentId; }
            set
            {
                _studentId = value;
                OnPropertyChanged();
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
                Contact.Type = value.ToString();
            }
        }

        private bool _isStudent;
        public bool IsStudent
        {
            get { return _isStudent; }
            set
            {
                _isStudent = value;
                Contact.Type = value.ToString();
            }
        }

        public AddContactViewModel(IContactService contactService)
        {
            _contactService = contactService;
            SubmitCommand = new Command(Submit);
            ResetCommand = new Command(ResetForm);
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
        private void Submit()
        {
            if (ValidateForm())
            {
                _contactService.AddContact(Contact, StudentId);
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
            if (IsFieldEmpty(Contact.Id, "Contact Id") || IsFieldEmpty(Contact.FirstName, "First Name") || IsFieldEmpty(Contact.LastName, "Last Name") ||
                IsFieldEmpty(Contact.Email, "Email"))
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

            return true;
        }

        private void ResetForm()
        {
            Contact.Id = Contact.FirstName = Contact.LastName = Contact.Email = Contact.MobileNumber = string.Empty;
            IsFaculty = IsStudent = false;
            SelectedSchoolProgram = SelectedCourse = pickerDefaultValue;
        }
    }
}
