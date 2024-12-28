using Microsoft.EntityFrameworkCore;
using StudentManagamentShared.Models;
using StudentManagamentShared.StudentRepository;
using StudentsManagement.Data;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Services
{
    public class SystemCodeDetailRepository : ISystemCodeDetailsRepository
    {
        private readonly ApplicationDbContext _context;

        public SystemCodeDetailRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<SystemCodeDetails> AddAsync(SystemCodeDetails mod)
        {
            if (mod == null) return null;

            var data = _context.SystemCodeDetails.Add(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }


        public async Task<SystemCodeDetails> DeleteAsync(int id)
        {
            var data = await _context.SystemCodeDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            _context.SystemCodeDetails.Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<List<SystemCodeDetails>> GetAllAsync()
        {
            var data = await _context.SystemCodeDetails
                .Include(x=>x.SystemCode)
                .ToListAsync();

            return data;
        }

        public async Task<SystemCodeDetails> GetByIdAsync(int id)
        {
            var data = await _context.SystemCodeDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            return data;
        }


        public async Task<List<SystemCodeDetails>> GetByCodeAsync(string code)
        {
            var data = await _context.SystemCodeDetails
                .Include(x => x.SystemCode)
                .Where(x => x.SystemCode.Code == code).ToListAsync();
            if (data == null) return null;

            return data;
        }

        public async Task<SystemCodeDetails> UpdateAsync(SystemCodeDetails mod)
        {
            if (mod == null) return null;

            var data = _context.SystemCodeDetails.Update(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }
    }
}
