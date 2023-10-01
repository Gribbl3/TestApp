using System.Collections.ObjectModel;
using System.Windows.Input;
using TestApp.Model;
using TestApp.Service;

namespace TestApp.ViewModel
{
    public class AddContactViewModel : BaseViewModel
    {
        private readonly IContactService _contactService;
        private readonly Student _student;
        public Model.Contact Contact { get; set; } = new();
        private ObservableCollection<Model.Contact> _contactCollection = new();
        public ICommand SubmitCommand => new Command(Submit);
        public ICommand ResetCommand => new Command(ResetForm);

        public AddContactViewModel(IContactService contactService, Student student)
        {
            _contactService = contactService;
            _student = student;
        }

        private void Submit()
        {
            if (ValidateForm())
            {
                _contactService.AddContact(Contact, _student);
                Shell.Current.DisplayAlert("Success", "Contact added successfully", "Ok");
                Shell.Current.GoToAsync("..");
            }
        }
        private bool ValidateForm()
        {
            _contactCollection = _contactService.GetContacts(_student).Result;
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
