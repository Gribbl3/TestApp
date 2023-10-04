using TestApp.Service;
using Contact = TestApp.Model.Contact;
namespace TestApp.ViewModel
{
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
                Shell.Current.GoToAsync("..");
            }
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

        private void ResetForm(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
