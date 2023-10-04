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
        public ICommand AddContactCommand => new Command(AddContact);
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

        public HomeViewModel(IContactService contactsService)
        {
            _contactsService = contactsService;
        }

        private async void AddContact()
        {
            //pass 
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
                ContactCollection = new ObservableCollection<Contact>();
                return;
            }

            string json = File.ReadAllText(contactsFilePath);
            var results = JsonSerializer.Deserialize<ObservableCollection<Contact>>(json);
            ContactCollection = new ObservableCollection<Contact>(results);
        }

    }
}
