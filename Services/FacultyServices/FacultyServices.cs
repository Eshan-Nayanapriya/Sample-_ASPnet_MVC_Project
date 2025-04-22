using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testMVCProject.Models;

namespace Services.FacultyServices
{
    public class FacultyServices : IFacultyRepository
    {
        private readonly TestDbContext _DbContext = new TestDbContext();
        public async Task<Faculty> Add(Faculty obj)
        {
            await _DbContext.AddAsync(obj);
            await _DbContext.SaveChangesAsync();
            return await _DbContext.Faculties.FindAsync(obj.Id);
        }

        public async Task<List<Faculty>> GetAll()
        {
            return await _DbContext.Faculties.ToListAsync();
        }

        public async Task<Faculty> GetById(long id)
        {
            return await _DbContext.Faculties.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task update(Faculty obj)
        {
            await _DbContext.SaveChangesAsync();
        }
    }
}
