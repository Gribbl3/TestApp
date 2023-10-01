using System.Collections.ObjectModel;

namespace TestApp.ViewModel
{
    public class HomeViewModel
    {
        private ObservableCollection<Model.Contact> _contactList = new ObservableCollection<Model.Contact>();

        public ObservableCollection<Model.Contact> ContactList
        {
            get { return _contactList; }
            set { _contactList = value; }
        }

        public HomeViewModel()
        {
            ContactList.Add(new Model.Contact { FirstName = "John Doe", MobileNumber = "09123456789" });

        }
    }
}
