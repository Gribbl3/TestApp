namespace TestApp.Service
{
    public class ContactService : IContactService
    {
        public Task<bool> AddContact(Model.Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<List<Model.Contact>> GetContacts()
        {
            throw new NotImplementedException();
        }
    }
}
