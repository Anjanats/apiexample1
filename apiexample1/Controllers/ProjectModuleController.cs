using Business.Logic;
using Microsoft.AspNetCore.Mvc;



namespace apiexample1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectModuleController : ControllerBase
    {

        private readonly ProjectModuleLogic _projectModuleLogic;
        public ProjectModuleController(ProjectModuleLogic projectModuleLogic)
        {
            _projectModuleLogic = projectModuleLogic;
        }
  
    }
}


