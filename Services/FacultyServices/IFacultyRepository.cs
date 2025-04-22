using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testMVCProject.Models;

namespace Services.FacultyServices
{
    public interface IFacultyRepository
    {
        public Task<List<Faculty>> GetAll();

        public Task<Faculty> GetById(long id);

        public Task update(Faculty obj);

        public Task<Faculty> Add(Faculty obj);
    }
}
