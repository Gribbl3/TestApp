using System.Collections.ObjectModel;
using System.Windows.Input;
using TestApp.Model;
using TestApp.Service;

namespace TestApp.ViewModel
{
    public class HomeViewModel
    {
        private readonly IContactService _contactsService;
        private readonly Student _student;
        private ObservableCollection<Model.Contact> _contactList = new ObservableCollection<Model.Contact>();
        public ICommand AddContactCommand => new Command(AddContact);
        public ObservableCollection<Model.Contact> ContactList
        {
            get { return _contactList; }
            set { _contactList = value; }
        }

        public HomeViewModel(IContactService contactsService, Student student)
        {
            _contactsService = contactsService;
            _student = student;
        }

        private async void AddContact()
        {
            await Shell.Current.GoToAsync(nameof(View.AddContact));
        }

        public async void LoadContacts()
        {
            var contacts = await _contactsService.GetContacts(_student);
            foreach (var contact in contacts)
            {
                ContactList.Add(contact);
            }
        }

    }
}
