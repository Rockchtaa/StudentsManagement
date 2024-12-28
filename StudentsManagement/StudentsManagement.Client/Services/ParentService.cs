using StudentsManagement.Client.Repository;
using StudentsManagement.Shared.Models;
using System.Net.Http.Json;

namespace StudentsManagement.Client.Services
{
    public class ParentService : IParentRepository
    {
        private readonly HttpClient _httpClient;
        public ParentService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<Parent> AddAsync(Parent mod)
        {
            var parentResponse = await _httpClient.PostAsJsonAsync("api/Parent/AddParent", mod);
            return await parentResponse.Content.ReadFromJsonAsync<Parent>();
        }

        public async Task<Parent> DeleteAsync(int id)
        {
            var parentResponse = await _httpClient.DeleteAsync($"api/Parent/DeleteParent/{id}");
            return await parentResponse.Content.ReadFromJsonAsync<Parent>();
        }

        public async Task<List<Parent>> GetAllAsync()
        {
            var allParents = await _httpClient.GetFromJsonAsync<List<Parent>>("api/Parent/GetParents");
            return allParents;
        }

        public async Task<Parent> GetByIdAsync(int id)
        {
            var singleParent = await _httpClient.GetFromJsonAsync<Parent>($"api/Parent/GetSingleParent/{id}");
            return singleParent;
        }

        public async Task<Parent> UpdateAsync(Parent mod)
        {
            var parentResponse = await _httpClient.PutAsJsonAsync("api/Parent/UpdateParent", mod);
            return await parentResponse.Content.ReadFromJsonAsync<Parent>();
        }
    }
}
