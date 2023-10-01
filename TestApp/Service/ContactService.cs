using System.Text.Json;

namespace TestApp.Service
{
    public class ContactService : IContactService
    {
        private readonly string mainDir = FileSystem.Current.AppDataDirectory;
        public Task<bool> AddContact(Model.Contact contact)
        {
            if (contact == null)
            {
                return Task.FromResult(false);
            }

            string contactsFilePath = Path.Combine(mainDir, $"s{contact.Id}.json");
            if (!File.Exists(contactsFilePath))
            {
                var json = JsonSerializer.Serialize(contact);
                File.WriteAllText(contactsFilePath, json);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<List<Model.Contact>> GetContacts(Model.Contact contact)
        {
            string contactsFilePath = Path.Combine(mainDir, $"s{contact.Id}.json");
            if (!File.Exists(contactsFilePath))
            {
                return Task.FromResult(new List<Model.Contact>());
            }

            string json = File.ReadAllText(contactsFilePath);
            var contactList = JsonSerializer.Deserialize<List<Model.Contact>>(json);

            return Task.FromResult(contactList);
        }
    }
}
