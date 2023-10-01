using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TestApp.ViewModel
{
    public class HomeViewModel
    {
        private ObservableCollection<Model.Contact> _contactList = new ObservableCollection<Model.Contact>();
        public ICommand AddContactCommand => new Command(AddContact);
        public ObservableCollection<Model.Contact> ContactList
        {
            get { return _contactList; }
            set { _contactList = value; }
        }

        public HomeViewModel()
        {
            ContactList.Add(new Model.Contact { LastName = "Lozada", FirstName = "John Doe", MobileNumber = "09123456789", Course = "BS Otin", SchoolProgram = "olok", Email = "allendakogotin@gmail.com", Id = "12321", Type = "Faculty" });
            ContactList.Add(new Model.Contact { LastName = "Allen", FirstName = "John Doe", MobileNumber = "09123456789", Course = "BS Otin", SchoolProgram = "olok", Email = "allendakogotin@gmail.com", Id = "12321", Type = "Faculty" });
            ContactList.Add(new Model.Contact { LastName = "Lozada", FirstName = "John Doe", MobileNumber = "09123456789", Course = "BS Otin", SchoolProgram = "olok", Email = "allendakogotin@gmail.com", Id = "12321", Type = "Faculty" });
        }

        private void AddContact()
        {

        }
    }
}
