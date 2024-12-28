using StudentManagamentShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagamentShared.StudentRepository
{
    public interface ISystemCodeRepository
    {
        Task<SystemeCode> AddAsync(SystemeCode mod);
        Task<SystemeCode> UpdateAsync(SystemeCode mod);

        Task<SystemeCode> DeleteAsync(int id);

        Task<List<SystemeCode>> GetAllAsync();

        Task<SystemeCode> GetByIdAsync(int id);

    }
}
