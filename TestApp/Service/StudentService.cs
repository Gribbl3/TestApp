using System.Collections.ObjectModel;
using System.Text.Json;
using TestApp.Model;

namespace TestApp.Service
{
    public class StudentService : IStudentService
    {
        readonly string mainDir = FileSystem.Current.AppDataDirectory;

        public Task<bool> AddStudent(Student student)
        {
            ObservableCollection<Student> studentCollection = GetStudentCollection().Result;
            if (student == null)
            {
                return Task.FromResult(false);
            }

            string usersFilePath = Path.Combine(mainDir, "Users.json");
            studentCollection.Add(student);

            var json = JsonSerializer.Serialize<ObservableCollection<Student>>(studentCollection);
            File.WriteAllText(usersFilePath, json);
            return Task.FromResult(true);

        }

        public Task<ObservableCollection<Student>> GetStudentCollection()
        {
            string filePath = Path.Combine(mainDir, "Users.json");
            if (!File.Exists(filePath))
            {
                return Task.FromResult(new ObservableCollection<Student>());
            }

            string json = File.ReadAllText(filePath);
            var studentList = JsonSerializer.Deserialize<ObservableCollection<Student>>(json);

            return Task.FromResult(studentList);
        }
    }
}
