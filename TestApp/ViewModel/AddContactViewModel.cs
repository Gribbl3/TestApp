using System.Collections.ObjectModel;
using System.Windows.Input;
using TestApp.Model;
using TestApp.Service;
using Contact = TestApp.Model.Contact;
namespace TestApp.ViewModel
{
    [QueryProperty(nameof(StudentId), "id")]
    public class AddContactViewModel : BaseViewModel
    {
        private readonly IContactService _contactService;
        public Contact Contact { get; set; } = new();
        private ObservableCollection<Contact> _contactCollection;
        public ICommand SubmitCommand => new Command(Submit);
        public ICommand ResetCommand => new Command(ResetForm);

        private string _studentId;
        public string StudentId
        {
            get { return _studentId; }
            set 
            { 
                _studentId = value; 
                OnPropertyChanged(nameof(StudentId)); 
            }
        }
        public AddContactViewModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        private void Submit()
        {
            if (ValidateForm())
            {
                _contactService.AddContact(Contact, StudentId);
                Shell.Current.DisplayAlert("Success", "Contact added successfully", "Ok");
                Shell.Current.GoToAsync("..");
            }
        }
        private bool ValidateForm()
        {
            _contactCollection = _contactService.GetContacts(StudentId).Result;
            if (IsFieldEmpty(Contact.Id, "Contact Id") || IsFieldEmpty(Contact.FirstName, "First Name") || IsFieldEmpty(Contact.LastName, "Last Name") ||
                IsFieldEmpty(Contact.Email, "Email"))
            {
                return false;
            }

            if (!IsMinLength((Contact.Id), 5, "Id"))
            {
                return false;
            }

            string defaultValue = "--SELECT--";
            if (!IsDefaultValue(Contact.SchoolProgram, defaultValue, "School Program") || !IsDefaultValue(Contact.Course, defaultValue, "Course"))
            {
                return false;
            }

            return true;
        }


        private void ResetForm(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
