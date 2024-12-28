using StudentManagamentShared.Models;
using StudentManagamentShared.StudentRepository;
using System.Net.Http.Json;

namespace StudentsManagement.Client.Services
{
    public class SystemCodeDetailService : ISystemCodeDetailsRepository
    {
        private readonly HttpClient _httpClient;

        public SystemCodeDetailService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<SystemCodeDetails> AddAsync(SystemCodeDetails mod)
        {
            var response = await _httpClient.PostAsJsonAsync("api/SystemCodeDetails/AddSystemCodeDetail", mod);
            return await response.Content.ReadFromJsonAsync<SystemCodeDetails>();
        }

        public async Task<SystemCodeDetails> DeleteAsync(int id)
        {
            var response = _httpClient.DeleteAsync($"api/SystemCodeDetails/DeleteSystemCodeDetail/{id}");
            return await response.Result.Content.ReadFromJsonAsync<SystemCodeDetails>();
        }

        public async Task<List<SystemCodeDetails>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<SystemCodeDetails>>("api/SystemCodeDetails/GetSystemCodeDetails");
            return response;
        }

        public async Task<List<SystemCodeDetails>> GetByCodeAsync(string code)
        {
            var response = await _httpClient.GetFromJsonAsync<List<SystemCodeDetails>>($"api/SystemCodeDetails/GetSystemCodeDetailsByCode/{code}");
            return response;
           
        }

        public async Task<SystemCodeDetails> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<SystemCodeDetails>($"api/SystemCodeDetails/GetSingleSystemCodeDetail/{id}");
            return response;
        }

        public async Task<SystemCodeDetails> UpdateAsync(SystemCodeDetails mod)
        {
            var response = await _httpClient.PutAsJsonAsync("api/SystemCodeDetails/UpdateSystemCodeDetail", mod);
            return await response.Content.ReadFromJsonAsync<SystemCodeDetails>();
        }
    }
}
