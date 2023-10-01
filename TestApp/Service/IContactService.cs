namespace TestApp.Service
{
    public interface IContactService
    {
        public Task<List<Model.Contact>> GetContacts();
        public Task<bool> AddContact(Model.Contact contact);
    }
}
