using TestApp.Model;

namespace TestApp.Service
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentList();
        Task<bool> AddStudent(Student student);
    }
}
