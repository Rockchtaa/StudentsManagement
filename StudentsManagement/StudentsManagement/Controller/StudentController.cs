using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagamentShared.StudentRepository;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }
        
        [HttpGet("GetStudents")]
        public async Task<ActionResult<List<Student>>> GetStudentsAsync()
        {
            var students = await _studentRepository.GetStudentsAsync();
            return students;
        }

        [HttpGet("GetSingleStudent/{id}")]
        public async Task<ActionResult<Student>> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            return student;
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult<Student>> AddStudentAsync(Student student)
        {
            var NewStudent = await _studentRepository.AddStudentAsync(student);
            return NewStudent;
        }

        [HttpDelete("DeleteStudent/{id}")] 
        public async Task<bool> DeleteStudentAsync(int id)
        {
            var isDeleted = await _studentRepository.DeleteStudentAsync(id);
            return isDeleted;
        }


        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<Student>> UpdateStudentAsync(Student student)
        {
            var updatedStudent = await _studentRepository.UpdateStudentAsync(student);
            return updatedStudent;
        }


    }
}
