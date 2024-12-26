using Microsoft.EntityFrameworkCore;
using StudentManagamentShared.Models;
using StudentManagamentShared.StudentRepository;
using StudentsManagement.Data;
using StudentsManagement.Migrations;

namespace StudentsManagement.Services
{
    public class SystemCodeRepository : ISystemCodeRepository
    {
        private readonly ApplicationDbContext _context;

        public SystemCodeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<SystemeCode> AddAsync(SystemeCode mod)
        {
            if (mod == null) return null;

            var data = _context.SystemeCodes.Add(mod).Entity;
            await _context.SaveChangesAsync();
            return data;
        }


        public async Task<SystemeCode> DeleteAsync(int id)
        {
            var data = await _context.SystemeCodes.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            _context.SystemeCodes.Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<List<SystemeCode>> GetAllAsync()
        {
            var data = await _context.SystemeCodes.ToListAsync();
            return data;
        }

        public async Task<SystemeCode> GetByIdAsync(int id)
        {
            var data = await _context.SystemeCodes.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;
            return data;
        }

        public async Task<SystemeCode> UpdateAsync(SystemeCode mod)
        {
            if (mod == null) return null;

            var data = _context.SystemeCodes.Update(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }

    }
}
