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

            string fileName = Path.Combine(mainDir, "student.json");
            if (File.Exists(fileName))
            {
                var json = JsonSerializer.Serialize(student);
                File.WriteAllText(fileName, json);

                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<List<Student>> GetStudentList()
        {
            throw new NotImplementedException();
        }
    }
}
