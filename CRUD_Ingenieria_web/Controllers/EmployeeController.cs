using CRUD_Ingenieria_web.Data;
using CRUD_Ingenieria_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace CRUD_Ingenieria_web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _contex;

        public EmployeeController(EmployeeContext contex)
        {
            _contex = contex;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _contex.Employees.ToListAsync();
            return View(employees);
        }

        public IActionResult Create ()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                _contex.Employees.Add(employee);
                await _contex.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var employeeinDB = await _contex.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (employeeinDB == null)
                return NotFound();

            return View(employeeinDB);



        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public  async Task<IActionResult> Edit(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            
            _contex.Employees.Update(employee);
            await _contex.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public  async Task<IActionResult> Delete(int? id, string _role)
        {
            if(_role == "admin")
            {
                if (id == null || id <= 0)
                    return BadRequest();

                var employeeInDb = await _contex.Employees.FirstOrDefaultAsync(e => e.Id == id);
                if (employeeInDb == null)
                    return NotFound();
                _contex.Employees.Remove(employeeInDb);
                await _contex.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
