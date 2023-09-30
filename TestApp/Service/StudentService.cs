using TestApp.Model;

namespace TestApp.Service
{
    public class StudentService : IStudentService
    {
        public Task<bool> AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetStudentList()
        {
            throw new NotImplementedException();
        }
    }
}
