using Company.Data.Models;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using Company.Service.Services;
using Company.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeesService _employeesService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeesService employeesService, IDepartmentService departmentService)
        {
            _employeesService = employeesService;
            _departmentService = departmentService;
        }

        public IActionResult Index(string searchInp)
        {
            //    ViewBag.Message = "Hello From Employee Index(ViewBag)";
            //    ViewData["TextMessage"] = "Hello From Employee Index(ViewData)";
            //    TempData["TextTempMessage"] = "Hello From Employee Index(TempData)";
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();

            if (string.IsNullOrEmpty(searchInp))
                employees = _employeesService.GetAll();
            else
                employees = _employeesService.GetEmployeeByName(searchInp);

            return View(employees);
        }



        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeesService.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                return View(employee);
            }
        }
    }
}
