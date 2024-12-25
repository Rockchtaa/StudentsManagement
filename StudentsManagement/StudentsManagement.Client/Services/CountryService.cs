
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

        public Task<Country> AddCountryAsync(Country country)
        {
            var countryResponse = _httpClient.PostAsJsonAsync("api/Country/AddCountry", country);
            return countryResponse.Result.Content.ReadFromJsonAsync<Country>();
        }

        public Task<bool> DeleteCountryAsync(int id)
        {
            var countryResponse = _httpClient.DeleteAsync($"api/Country/DeleteCountry/{id}");
            return countryResponse.Result.Content.ReadFromJsonAsync<bool>();
        }

        public Task<List<Country>> GetCountriesAsync()
        {
            var allCountries = _httpClient.GetFromJsonAsync<List<Country>>("api/Country/GetCountries");
            return allCountries;
        }

        public Task<Country> GetCountryByIdAsync(int id)
        {
            var singleCountry = _httpClient.GetFromJsonAsync<Country>($"api/Country/GetSingleCountry/{id}");
            return singleCountry;
        }

        public Task<Country> UpdateCountryAsync(Country country)
        {
            var countryResponse = _httpClient.PutAsJsonAsync("api/Country/UpdateCountry", country);
            return countryResponse.Result.Content.ReadFromJsonAsync<Country>();
        }
    }
}
