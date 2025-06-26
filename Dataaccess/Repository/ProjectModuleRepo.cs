using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Oracle;
using Dataaccess.Context;
using Dataaccess.Models;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Types;
using Dapper;

namespace Dataaccess.Repository
{
    public class ProjectModuleRepo : ControllerBase
    {

        private readonly DataContext _datacontext;
        private readonly ProjectModel _projectmodel;
        public ProjectModuleRepo(DataContext datacontext, ProjectModel projectmodel)
        {
            _datacontext = datacontext;
            _projectmodel = projectmodel;
        }


        [HttpGet("GetDetailsRepo2")]

        public async Task<IActionResult> GetDetailsRepo2()
        {
            OracleRefCursor result = null;
            var procedureName = "proc_project";
            var parameters = new OracleDynamicParameters();

            parameters.Add("project_refcur", result, OracleMappingType.RefCursor,ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _datacontext.CreateConnection();
            var response = await connection.QueryAsync<ProjectModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure
                );

            if (response == null || !response.Any())
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}

