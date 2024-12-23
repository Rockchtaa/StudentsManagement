using Microsoft.EntityFrameworkCore;
using StudentManagamentShared.StudentRepository;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)  
        {
            this._context = context;
        }

    
        public async Task<Student> AddStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var newStudent = _context.students.Add(student).Entity;
            await _context.SaveChangesAsync();

            return newStudent;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {

            var student =  _context.students.Find(id);
            if (student == null) return false;
            _context.students.Remove(student);
            await  _context.SaveChangesAsync();
            return true;
  
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var singleStudent = await _context.students.FindAsync(id);
            return singleStudent;
        }
        
        public async  Task<List<Student>> GetStudentsAsync()
        {
            var students = await _context.students.ToListAsync();
            return students;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _context.students.Update(student);
            await _context.SaveChangesAsync();
            return student;

        }
    }
}
