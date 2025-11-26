using StudentManagementDapper.Interfaces;
using StudentManagementDapper.Models;

namespace StudentManagementDapper.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Student>> GetAllStudentsAsync() => _repository.GetAllAsync();

        public Task<Student?> GetStudentByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<int> AddStudentAsync(Student student) => _repository.CreateAsync(student);

        public Task<bool> UpdateStudentAsync(Student student) => _repository.UpdateAsync(student);

        public Task<bool> DeleteStudentAsync(int id) => _repository.DeleteAsync(id);
    }
}
