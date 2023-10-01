namespace TestApp.Service
{
    public interface IContactService
    {
        public Task<List<Model.Contact>> GetContacts(Model.Contact contact);
        public Task<bool> AddContact(Model.Contact contact);
    }
}
