using Business.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace apiexample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeModuleController : ControllerBase
    {

        private readonly EmployeeModuleLogic _employeeModuleLogic;
        public EmployeeModuleController(EmployeeModuleLogic employeeModuleLogic)
        {
            _employeeModuleLogic = employeeModuleLogic;
        }

        [HttpGet("GetName/{name}")]
        public string GetName([FromRoute] string name)
        {

            return _employeeModuleLogic.GetNameService(name);

        }


        [HttpGet("GetDetails1")]
        public async Task<IActionResult> GetDetails1()
        {
            var employeeDetails = await _employeeModuleLogic.GetDetailsLogic1();

            if (employeeDetails == null)
            {
                return NotFound();
            }

            return Ok(employeeDetails);
        }

        [HttpGet("GetDetails3")]
        public async Task<IActionResult> GetDetails3(string flag,string para1,string para2)
        {
            var employeeDetailsResult = await _employeeModuleLogic.GetDetailsLogic3(flag,para1,para2);

            if (employeeDetailsResult is IActionResult actionResult)
            {
                return actionResult;
            }

            return BadRequest();
        }
    }
}
