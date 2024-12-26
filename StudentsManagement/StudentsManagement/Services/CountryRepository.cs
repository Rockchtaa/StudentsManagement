using Microsoft.EntityFrameworkCore;
using StudentManagamentShared.Models;
using StudentManagamentShared.StudentRepository;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Services
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Country> AddCountryAsync(Country country)
        {
            if (country == null) return null;

            var newcountry = _context.Countries.Add(country).Entity;
            await _context.SaveChangesAsync();

            return newcountry;
        }

        public async Task<bool> DeleteCountryAsync(int id)
        {
            var country = _context.Countries.Find(id);
            if (country == null) return false;
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<List<Country>> GetCountriesAsync()
        {
            var countries = await _context.Countries.ToListAsync();

            return countries;
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            var singlecountry = await _context.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (singlecountry == null) return null;

            return singlecountry;
        }

        public async Task<Country> UpdateCountryAsync(Country country)
        {
            if (country == null) return null;

            var updatedcountry = _context.Countries.Update(country).Entity;
            await _context.SaveChangesAsync();

            return updatedcountry;
        }
    }
}