using Dapper;
using StudentManagementDapper.Data;
using StudentManagementDapper.Interfaces;
using StudentManagementDapper.Models;

namespace StudentManagementDapper.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperContext _context;

        public StudentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var sql = "SELECT * FROM Students";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Student>(sql);
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Students WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Student>(sql, new { Id = id });
        }

        public async Task<int> CreateAsync(Student student)
        {
            var sql = @"INSERT INTO Students (Name, Email, RegistrationNumber, DateOfBirth, Department)
                        VALUES (@Name, @Email, @RegistrationNumber, @DateOfBirth, @Department);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

            using var connection = _context.CreateConnection();
            return await connection.QuerySingleAsync<int>(sql, student);
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            var sql = @"UPDATE Students SET 
                        Name = @Name,
                        Email = @Email,
                        RegistrationNumber = @RegistrationNumber,
                        DateOfBirth = @DateOfBirth,
                        Department = @Department
                        WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            var rows = await connection.ExecuteAsync(sql, student);

            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Students WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            var rows = await connection.ExecuteAsync(sql, new { Id = id });

            return rows > 0;
        }
    }
}
