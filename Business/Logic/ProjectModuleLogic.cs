using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataaccess.Repository;

namespace Business.Logic
{
    public class ProjectModuleLogic
    {

        private readonly ProjectModuleRepo _projectModuleRepo;
        public ProjectModuleLogic(ProjectModuleRepo projectModuleRepo)
        {
            _projectModuleRepo = projectModuleRepo;


        }
    }
}
