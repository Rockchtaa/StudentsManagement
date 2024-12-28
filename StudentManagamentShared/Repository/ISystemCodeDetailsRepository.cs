using StudentManagamentShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagamentShared.StudentRepository
{
    public interface ISystemCodeDetailsRepository
    {
        Task<SystemCodeDetails> AddAsync(SystemCodeDetails mod);
        Task<SystemCodeDetails> UpdateAsync(SystemCodeDetails mod);
        Task<SystemCodeDetails> DeleteAsync(int id);
        Task<SystemCodeDetails> GetByIdAsync(int id);
        Task<List<SystemCodeDetails>> GetAllAsync();
        Task<List<SystemCodeDetails>> GetByCodeAsync(string code);


    }
}
