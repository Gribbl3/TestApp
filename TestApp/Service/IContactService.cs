using System.Collections.ObjectModel;
using TestApp.Model;

namespace TestApp.Service
{
    public interface IContactService
    {
        public Task<ObservableCollection<Model.Contact>> GetContacts(Student student);
        public Task<bool> AddContact(Model.Contact contact, Student student);
    }
}
