using Microsoft.AspNetCore.Mvc;
using TASK_poiner.DTOS;
using TASK_poiner.Service.Employees;
using TASK_poiner.Service.Propertys;


namespace TASK_poiner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeePropertyService _empservice;
        IPropertyService propertyservice;

        public EmployeeController(IEmployeePropertyService service,IPropertyService propertyService )
        {
            this._empservice = service;
            this.propertyservice = propertyService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _empservice.GetAllWithProperties();
            return Ok(employees); 
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _empservice.GetById(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EmployeeDTO employeeVm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            _empservice.Create(employeeVm);
            return CreatedAtAction(nameof(GetById), new { id = employeeVm.EmployeeId }, employeeVm); // 201 Created
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EmployeeDTO employeeVm)
        {
            if (id != employeeVm.EmployeeId)
                return BadRequest("Employee ID Not Found.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _empservice.Update(id, employeeVm);
            return Ok("Updated Succesfull"); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _empservice.DeleteById(id);
            return Ok("Deleted Succesfully"); 
        }
    }
}
