using System.Collections.ObjectModel;
using TestApp.Model;

namespace TestApp.Service
{
    public interface IStudentService
    {
        Task<ObservableCollection<Student>> GetStudentCollection();
        Task<bool> AddStudent(Student student);
    }
}
