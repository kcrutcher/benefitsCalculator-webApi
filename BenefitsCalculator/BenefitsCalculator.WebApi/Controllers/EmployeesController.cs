﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BenefitsCalculator.Common.Entities;
using BenefitsCalculator.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BenefitsCalculator.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeLogic _employeeLogic;
        private const string NameOfGetById = "GetById";

        public EmployeesController(IEmployeeLogic employeeLogic)
        {
            this._employeeLogic = employeeLogic;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Employee> employees = await this._employeeLogic.GetItemsAsync();

            return Ok(employees);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = NameOfGetById)]
        public async Task<IActionResult> GetById(int id)
        {
            Employee employee = await this._employeeLogic.GetItemAsync(id);

            if (employee == null)
            {
                return NotFound(employee);
            }

            return Ok(employee);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Employee value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Employee employee = await this._employeeLogic.AddItemAsync(value);

            return CreatedAtRoute(NameOfGetById, new { id = employee.Id }, employee);
        }
    }
}