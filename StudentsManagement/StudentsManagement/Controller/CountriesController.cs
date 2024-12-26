using Microsoft.AspNetCore.Mvc;
using StudentManagamentShared.Models;
using StudentManagamentShared.StudentRepository;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            this._countryRepository = countryRepository;
        }

        [HttpGet("GetCountries")]
        public async Task<ActionResult<List<Country>>> GetCountriesAsync()
        {
            var countries = await _countryRepository.GetCountriesAsync();
            return countries;
        }

        [HttpGet("GetSingleCountry/{id}")]
        public async Task<ActionResult<Country>> GetCountryByIdAsync(int id)
        {
            var country = await _countryRepository.GetCountryByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return country;
        }

        [HttpPost("AddCountry")]
        public async Task<ActionResult<Country>> AddCountryAsync(Country country)
        {
            var newCountry = await _countryRepository.AddCountryAsync(country);
            return newCountry;
        }

        [HttpDelete("DeleteCountry/{id}")]
        public async Task<ActionResult<bool>> DeleteCountryAsync(int id)
        {
            var isDeleted = await _countryRepository.DeleteCountryAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return isDeleted;
        }

        [HttpPut("UpdateCountry")]
        public async Task<ActionResult<Country>> UpdateCountryAsync(Country country)
        {
            var updatedCountry = await _countryRepository.UpdateCountryAsync(country);
            if (updatedCountry == null)
            {
                return NotFound();
            }
            return updatedCountry;
        }
    }
}
