using System.Collections.ObjectModel;

namespace TestApp.ViewModel
{
    public class ContactViewModel
    {
        private ObservableCollection<Model.Contact> _contactList = new ObservableCollection<Model.Contact>();

        public ObservableCollection<Model.Contact> ContactList
        {
            get { return _contactList; }
            set { _contactList = value; }
        }
    }
}
