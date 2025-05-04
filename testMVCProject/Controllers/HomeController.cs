using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Services.DepartmentServices;
using Services.FacultyServices;
using testMVCProject.Models;

namespace testMVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentRepository _departmentServices;
        private readonly IFacultyRepository _facultyServices;

        public HomeController(ILogger<HomeController> logger, IDepartmentRepository departmentServices, IFacultyRepository facultyRepository)
        {
            _logger = logger;
            _departmentServices = departmentServices;
            _facultyServices = facultyRepository;
        }

        public IActionResult Index()
        {
            var res = _departmentServices.GetAll().Result;
            ViewBag.Departmentlist = res;
            ViewBag.FacultyList = _facultyServices.GetAll().Result;
            ViewBag.Department = null;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> add(Department details)
        {
            var addDepartment = new Department();
            addDepartment.DepartmentName = details.DepartmentName;
            addDepartment.FacultyId = details.FacultyId;
            await _departmentServices.Add(addDepartment);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Manage(int Id)
        {
            var resDepartment = await _departmentServices.GetById(Id);

            var res = _departmentServices.GetAll().Result;
            ViewBag.Departmentlist = res;
            ViewBag.FacultyList = _facultyServices.GetAll().Result;
            ViewBag.Department = resDepartment;
            return View("Index");
        }
    }
}
