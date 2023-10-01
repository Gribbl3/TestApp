using System.Text.Json;
using TestApp.Model;

namespace TestApp.Service
{
    public class StudentService : IStudentService
    {
        readonly string mainDir = FileSystem.Current.AppDataDirectory;

        public Task<bool> AddStudent(Student student)
        {
            if (student == null)
            {
                return Task.FromResult(false);
            }

            string usersFilePath = Path.Combine(mainDir, "Users.json");
            if (!File.Exists(usersFilePath))
            {
                var json = JsonSerializer.Serialize(student);
                File.WriteAllText(usersFilePath, json);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<List<Student>> GetStudentList()
        {
            string filePath = Path.Combine(mainDir, "student.json");

            if (!File.Exists(filePath))
            {
                return Task.FromResult(new List<Student>());
            }

            string json = File.ReadAllText(filePath);
            var studentList = JsonSerializer.Deserialize<List<Student>>(json);

            return Task.FromResult(studentList);
        }
    }
}
