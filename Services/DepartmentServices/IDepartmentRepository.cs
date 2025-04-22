using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testMVCProject.Models;

namespace Services.DepartmentServices
{
    public interface IDepartmentRepository
    {
        public Task<List<Department>> GetAll();

        public Task<Department> GetById(long id);

        public Task update(Department obj);

        public Task<Department> Add(Department obj);
    }
}
