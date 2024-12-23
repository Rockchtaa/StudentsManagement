using StudentManagamentShared.StudentRepository;
using StudentsManagement.Shared.Models;
using System.Net.Http.Json;

namespace StudentsManagement.Client.Services
{
    public class StudentService : IStudentRepository
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            var studentResponse = await _httpClient.PostAsJsonAsync("api/Student/AddStudent", student);

            return await studentResponse.Content.ReadFromJsonAsync<Student>();
        }

        public Task<bool> DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentByIdAsync(int id)
        {
            var singleStudent = _httpClient.GetFromJsonAsync<Student>($"api/Student/GetSingleStudent/{id}");

            return singleStudent;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            var allStudents = await _httpClient.GetFromJsonAsync<List<Student>>("api/Student/GetStudents");

            return allStudents;
    
            
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            var studentResponse = _httpClient.PutAsJsonAsync("api/Student/UpdateStudent", student);

            return await studentResponse.Result.Content.ReadFromJsonAsync<Student>();
        }
    }
}
