
using StudentManagamentShared.Models;
using StudentManagamentShared.StudentRepository;
using System.Net.Http.Json;

namespace StudentsManagement.Client.Services
{
    public class CountryService : ICountryRepository
    {
        private readonly HttpClient _httpClient;
        public CountryService(HttpClient httpClient)
        {  
            this._httpClient = httpClient;
        }

        public async Task<Country> AddCountryAsync(Country country)
        {
            var countryResponse = _httpClient.PostAsJsonAsync("api/Country/AddCountry", country);
            return await countryResponse.Result.Content.ReadFromJsonAsync<Country>();
        }

        public async Task<bool> DeleteCountryAsync(int id)
        {
            var countryResponse =  _httpClient.DeleteAsync($"api/Country/DeleteCountry/{id}");
            return await countryResponse.Result.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            var allCountries = await _httpClient.GetFromJsonAsync<List<Country>>("api/Country/GetCountries");
            return allCountries;
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            var singleCountry = await _httpClient.GetFromJsonAsync<Country>($"api/Country/GetSingleCountry/{id}");
            return singleCountry;
        }

        public async Task<Country> UpdateCountryAsync(Country country)
        {
            var countryResponse = _httpClient.PutAsJsonAsync("api/Country/UpdateCountry", country);
            return await countryResponse.Result.Content.ReadFromJsonAsync<Country>();
        }
    }
}
