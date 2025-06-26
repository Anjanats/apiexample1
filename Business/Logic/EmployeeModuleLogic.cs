using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dataaccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Business.Logic
{
    public class EmployeeModuleLogic:ControllerBase

    {
        private readonly EmployeeModuleRepo _employeeModuleRepo;
        public EmployeeModuleLogic(EmployeeModuleRepo employeeModuleRepo)
        {
            _employeeModuleRepo = employeeModuleRepo;


        }

        public async Task<dynamic> GetDetailsLogic1()
        {
            var studentDetails = await _employeeModuleRepo.GetDetailsRepo1();

            if (studentDetails == null)
            {
                return NotFound();

            }

            return Ok(studentDetails);
        }


        public async Task<IActionResult> GetDetailsLogic3(string flag, string para1,string para2)
        {
            var employeeDetails = await _employeeModuleRepo.GetDetailsRepo3(flag, para1, para2);

            if (employeeDetails == null || !employeeDetails.Any())
            {
                return NotFound();

            }
            return Ok(employeeDetails);
        }

        public string GetNameService(string name)
        {
            return _employeeModuleRepo.GetNameRepo(name);
        }
       
    

}
}
