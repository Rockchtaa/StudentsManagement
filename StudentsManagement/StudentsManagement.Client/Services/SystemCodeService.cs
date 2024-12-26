using StudentManagamentShared.Models;
using StudentManagamentShared.StudentRepository;
using System.Net.Http.Json;

namespace StudentsManagement.Client.Services
{
    public class SystemCodeService : ISystemCodeRepository
    {
        private readonly HttpClient _httpClient;
        public SystemCodeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<SystemeCode> AddAsync(SystemeCode systeme)
        {
            var systemeResponse = await _httpClient.PostAsJsonAsync("api/SystemeCode/AddSystemeCode", systeme);
            return await systemeResponse.Content.ReadFromJsonAsync<SystemeCode>();
        }

        public async Task<List<SystemeCode>> GetAllAsync()
        {
            var allSysteme = await _httpClient.GetFromJsonAsync<List<SystemeCode>>("api/SystemeCode/GetSystemeCodes");
            return allSysteme;

        }

        public async Task<SystemeCode> GetByIdAsync(int id)
        {
            var singleSysteme = await _httpClient.GetFromJsonAsync<SystemeCode>($"api/SystemeCode/GetSingleSystemeCode/{id}");
            return singleSysteme;
          
        }

        public async Task<SystemeCode> UpdateAsync(SystemeCode systeme)
        {
            var systemeResponse = _httpClient.PutAsJsonAsync("api/SystemeCode/UpdateSystemeCode", systeme);
            return await systemeResponse.Result.Content.ReadFromJsonAsync<SystemeCode>();
        }

        Task<SystemeCode> ISystemCodeRepository.DeleteAsync(int id)
        {
            var systemeResponse = _httpClient.DeleteAsync($"api/SystemeCode/DeleteSystemeCode/{id}");
            return systemeResponse.Result.Content.ReadFromJsonAsync<SystemeCode>();
           
        }
    }
}
