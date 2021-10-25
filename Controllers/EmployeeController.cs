using Microsoft.AspNetCore.Mvc;
using MvcApp2.Models;
using System.Collections.Generic;

namespace MvcApp2.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string MyMethod()
        {
            return "I pink up the phone and say yellow!";
        }

        public IActionResult Index()
        {
            // Some/Index.cshtml
            //return View("~/Views/ABC.cshtml");
            return View();
        }

        public IActionResult List()
        {
            return View(_employeeRepository.GetAll());
        }

        public IActionResult Delete(int? id)
        {
            //if (id == null) return NotFound(); // 404
            //if (_employeeRepository.DeleteById((int)id))
            //{
            //    //return Ok(); // 200
            //    //return View("List", _employees);
            //    return RedirectToAction("List");
            //}
            //else
            //{
            //    return NotFound(); // 404
            //}

            return (id == null || !_employeeRepository.DeleteById((int)id)) 
                ? NotFound() 
                : RedirectToAction("List");
        }

        public IActionResult Create(string name)
        {
            _employeeRepository.Create(name);
            return RedirectToAction("List");
        }

        public IActionResult Details(int? id)
        {
            return id == null
                ? NotFound()
                : View(_employeeRepository.GetById((int)id));
        }

        public IActionResult Update(int id, string name)
        {
            _employeeRepository.Update(id, name);
            return RedirectToAction("Details", new { id = id });
        }

    }
}
