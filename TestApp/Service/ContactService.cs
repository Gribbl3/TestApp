using System.Collections.ObjectModel;
using System.Text.Json;
using TestApp.Model;

namespace TestApp.Service
{
    public class ContactService : IContactService
    {
        private readonly string mainDir = FileSystem.Current.AppDataDirectory;

        public Task<bool> AddContact(Model.Contact contact, Student student)
        {
            ObservableCollection<Model.Contact> contactCollection = GetContacts(student).Result;
            if (contact == null)
            {
                return Task.FromResult(false);
            }

            string contactsFilePath = Path.Combine(mainDir, $"s{student.Id}.json");
            contactCollection.Add(contact);

            var json = JsonSerializer.Serialize(contactCollection);
            File.WriteAllText(contactsFilePath, json);
            return Task.FromResult(true);

        }

        public Task<ObservableCollection<Model.Contact>> GetContacts(Student student)
        {
            string contactsFilePath = Path.Combine(mainDir, $"s{student.Id}.json");
            if (!File.Exists(contactsFilePath))
            {
                return Task.FromResult(new ObservableCollection<Model.Contact>());
            }

            string json = File.ReadAllText(contactsFilePath);
            var contactList = JsonSerializer.Deserialize<ObservableCollection<Model.Contact>>(json);

            return Task.FromResult(contactList);
        }
    }
}
