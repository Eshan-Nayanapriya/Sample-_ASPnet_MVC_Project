using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Services.DepartmentServices;
using testMVCProject.Models;

namespace testMVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentRepository _departmentServices;

        public HomeController(ILogger<HomeController> logger, IDepartmentRepository departmentServices)
        {
            _logger = logger;
            _departmentServices = departmentServices;
        }

        public IActionResult Index()
        {
            var res = _departmentServices.GetAll().Result;
            return View(res);
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
    }
}
