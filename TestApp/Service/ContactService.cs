using System.Collections.ObjectModel;
using System.Text.Json;
using Contact = TestApp.Model.Contact;

namespace TestApp.Service
{
    public class ContactService : IContactService
    {
        private readonly string mainDir = FileSystem.Current.AppDataDirectory;

        public Task<bool> AddContact(Contact contact, string studentId)
        {
            ObservableCollection<Contact> contactCollection = GetContacts(studentId).Result;
            if (contact == null)
            {
                return Task.FromResult(false);
            }

            string contactsFilePath = Path.Combine(mainDir, $"s{studentId}.json");
            contactCollection.Add(contact);

            var json = JsonSerializer.Serialize(contactCollection);
            File.WriteAllText(contactsFilePath, json);
            return Task.FromResult(true);
        }

        public Task<ObservableCollection<Contact>> GetContacts(string studentId)
        {
            string contactsFilePath = Path.Combine(mainDir, $"s{studentId}.json");
            if (!File.Exists(contactsFilePath))
            {
                return Task.FromResult(new ObservableCollection<Contact>());
            }

            string json = File.ReadAllText(contactsFilePath);
            if (json == string.Empty)
            {
                return Task.FromResult(new ObservableCollection<Contact>());
            }
            var contactList = JsonSerializer.Deserialize<ObservableCollection<Contact>>(json);

            return Task.FromResult(contactList);
        }
    }
}
