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
            await Shell.Current.GoToAsync($"{nameof(AddContact)}?id={StudentId}");
        }

        private void LoadContacts()
        {
            if (StudentId != null)
            {
                ContactCollection = _contactsService.GetContacts(_studentId).Result;
            }
        }

    }
}
