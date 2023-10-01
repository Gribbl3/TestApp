using System.Collections.ObjectModel;
using System.Windows.Input;
using TestApp.Service;

namespace TestApp.ViewModel
{
    public class HomeViewModel
    {
        private readonly IContactService _contactsService;
        private ObservableCollection<Model.Contact> _contactList = new ObservableCollection<Model.Contact>();
        public ICommand AddContactCommand => new Command(AddContact);
        public ObservableCollection<Model.Contact> ContactList
        {
            get { return _contactList; }
            set { _contactList = value; }
        }

        public HomeViewModel(IContactService contactsService)
        {
            _contactsService = contactsService;
            ContactList.Add(new Model.Contact { LastName = "Lozada", FirstName = "John Doe", MobileNumber = "09123456789", Course = "BS Otin", SchoolProgram = "olok", Email = "allendakogotin@gmail.com", Id = "12321", Type = "Faculty" });
            ContactList.Add(new Model.Contact { LastName = "Allen", FirstName = "John Doe", MobileNumber = "09123456789", Course = "BS Otin", SchoolProgram = "olok", Email = "allendakogotin@gmail.com", Id = "12321", Type = "Faculty" });
            ContactList.Add(new Model.Contact { LastName = "Lozada", FirstName = "John Doe", MobileNumber = "09123456789", Course = "BS Otin", SchoolProgram = "olok", Email = "allendakogotin@gmail.com", Id = "12321", Type = "Faculty" });
        }

        private async void AddContact()
        {
            await Shell.Current.GoToAsync("AddContactPage");
        }

        public async void LoadContacts()
        {
            var contacts = await _contactsService.GetContacts(new Model.Contact());
            foreach (var contact in contacts)
            {
                ContactList.Add(contact);
            }
        }

    }
}
