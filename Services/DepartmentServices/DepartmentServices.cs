using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testMVCProject.Models;

namespace Services.DepartmentServices
{
    public class DepartmentServices : IDepartmentRepository
    {
        private readonly TestDbContext _DbContext = new TestDbContext();
        public async Task<Department> Add(Department obj)
        {
            await _DbContext.AddAsync(obj);
            await _DbContext.SaveChangesAsync();
            return await _DbContext.Departments.FindAsync(obj.Id);
        }

        public async Task<List<Department>> GetAll()
        {
            return await _DbContext.Departments.ToListAsync();
        }

        public async Task<Department> GetById(long id)
        {
            return await _DbContext.Departments.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task update(Department obj)
        {
            await _DbContext.SaveChangesAsync();
        }
    }
}
