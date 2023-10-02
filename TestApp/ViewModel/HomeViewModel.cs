using System.Collections.ObjectModel;
using System.Windows.Input;
using TestApp.Service;
using Contact = TestApp.Model.Contact;

namespace TestApp.ViewModel
{
    [QueryProperty(nameof(StudentId), "id")]
    public class HomeViewModel : BaseViewModel
    {
        private readonly IContactService _contactsService;
        private ObservableCollection<Contact> _contactList;
        private string _studentId;
        public string StudentId
        {
            get { return _studentId; }
            set { _studentId = value; OnPropertyChanged(nameof(StudentId)); }
        }
        public ICommand AddContactCommand => new Command(AddContact);
        public ObservableCollection<Contact> ContactList
        {
            get { return _contactList; }
            set { _contactList = value; }
        }

        public HomeViewModel(IContactService contactsService)
        {
            _contactsService = contactsService;
            ContactList = _contactsService.GetContacts(StudentId).Result;
            //ContactList = new ObservableCollection<Contact>()
            //{
            //    new Contact()
            //    {
            //        Id = "1",
            //        FirstName = "John",
            //        LastName = "Doe",
            //        Email = ""
            //    }};
        }

        private async void AddContact()
        {
            await Shell.Current.GoToAsync($"{nameof(View.AddContact)}?id={StudentId}");
        }

        private void LoadContacts()
        {
            ContactList = _contactsService.GetContacts(StudentId).Result;
        }

    }
}
