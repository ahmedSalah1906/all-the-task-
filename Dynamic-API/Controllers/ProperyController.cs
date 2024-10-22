using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using TASK_poiner.models;

using TASK_poiner.Service.Propertys;

namespace TASK_poiner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProperyController : ControllerBase
    {
        IPropertyService propertyService;
        public ProperyController(IPropertyService propertyService) 
        { 
            this.propertyService = propertyService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var properties = propertyService.GetAllGlobalProperties();
            return Ok(properties); 
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var property = propertyService.GetGlobalPropertyById(id);
            if (property == null)
                return NotFound("this property is not found"); 

            return Ok(property);
        }

        [HttpPost]
        public IActionResult Add([FromBody] PropertyForEmployee newProperty)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            propertyService.AddGlobalProperty(newProperty);
            return CreatedAtAction(nameof(GetById), new { id = newProperty.Id }, newProperty); 
        }

        [HttpPut("{id}")]
        public IActionResult Update( [FromBody] PropertyForEmployee updatedProperty)
        {
            if (updatedProperty ==null)
                return BadRequest("Property cant found .");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            propertyService.UpdateGlobalProperty(updatedProperty);
            return Ok("Updeted Succesfully"); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var property = propertyService.GetGlobalPropertyById(id);
            if (property == null)
                return NotFound("this employee is not found Try again"); 

            propertyService.DeleteProperty(id);
            return Ok("Deleted Succesfully"); 
        }

    }
}
