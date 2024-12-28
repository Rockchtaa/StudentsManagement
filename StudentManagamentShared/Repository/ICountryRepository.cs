using StudentManagamentShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagamentShared.StudentRepository
{
    public interface ICountryRepository
    {
        Task<Country> AddCountryAsync(Country country);
        Task<Country> GetCountryByIdAsync(int id);
        Task<List<Country>> GetCountriesAsync();
        Task<Country> UpdateCountryAsync(Country country);
        Task<bool> DeleteCountryAsync(int id);
    }
}
