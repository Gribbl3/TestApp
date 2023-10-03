using System.Collections.ObjectModel;
using System.Text.Json;
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
            set 
            { 
                _studentId = value; 
                OnPropertyChanged(nameof(StudentId)); 
                LoadContacts(); 
            }
        }

        public ICommand AddContactCommand => new Command(AddContact);
        public ObservableCollection<Contact> ContactList
        {
            get { return _contactList; }
            set 
            { 
                _contactList = value;
                //observable collection is inheriting INotifyProperChanged but the OnPropertyChanged is not yet invoke.
                //we need to listen (event handlers) for the changes.
                OnPropertyChanged(nameof(ContactList));
            }

        }

        public HomeViewModel(IContactService contactsService)
        {
            _contactsService = contactsService;
        }

        private async void AddContact()
        {
            await Shell.Current.GoToAsync($"{nameof(View.AddContact)}?id={StudentId}");
        }

        private void LoadContacts()
        {
            //if(StudentId != null)
            //{
            //    ContactList = _contactsService.GetContacts(_studentId).Result;
            //}
            string mainDir = FileSystem.Current.AppDataDirectory;

            string contactsFilePath = Path.Combine(mainDir, $"s{_studentId}.json");
            if (!File.Exists(contactsFilePath))
            {
                ContactList = new ObservableCollection<Contact>();
                return;
            }

            string json = File.ReadAllText(contactsFilePath);
            var results =  JsonSerializer.Deserialize<ObservableCollection<Contact>>(json);
            ContactList = new ObservableCollection<Contact>(results);

        }

    }
}
