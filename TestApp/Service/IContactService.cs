using System.Collections.ObjectModel;
using Contact = TestApp.Model.Contact;
namespace TestApp.Service
{
    public interface IContactService
    {
        public Task<ObservableCollection<Contact>> GetContacts(string studentId);
        public Task<bool> AddContact(Contact contact, string studentId);
    }
}
