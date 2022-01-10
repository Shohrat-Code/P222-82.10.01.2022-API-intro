using APIIntro.Data;
using APIIntro.Models;
using APIIntro.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            List<DtoEmployee> dtoEmployees = new List<DtoEmployee>();
            foreach (var item in _context.Employees.ToList())
            {
                DtoEmployee dtoEmployee = new DtoEmployee();

                dtoEmployee.Id = item.Id;
                dtoEmployee.Name = item.Name;
                dtoEmployee.Surname = item.Surname;
                dtoEmployee.Age = item.Age;
                dtoEmployee.IsMarried = item.IsMarried;
                dtoEmployee.PositinId = item.PositinId;
                dtoEmployee.Position = _context.Positions.Select(p => new { p.Id, p.Name })
                    .FirstOrDefault(pa => pa.Id == item.PositinId);

                dtoEmployees.Add(dtoEmployee);
            };

            return Ok(dtoEmployees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int? id)
        {
            if (id == null)
            {
                //return BadRequest();

                //ModelState.AddModelError("", "Error nese oluf!");
                //return StatusCode(StatusCodes.Status400BadRequest, ModelState);

                return StatusCode(StatusCodes.Status400BadRequest, "Aee naqardin?!");
            }

            Employee employee = _context.Employees.Find(id);
            if (employee == null)
            {
                ModelState.AddModelError("", "Error, nese oluf!");
                return StatusCode(StatusCodes.Status404NotFound, ModelState);

                //return StatusCode(StatusCodes.Status400BadRequest, "Aee naqardin?!");
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                _context.Employees.Add(model);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }
    }
}
