using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataaccess.Context;
using Dataaccess.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.AspNetCore.Http;
using Oracle.ManagedDataAccess.Types;
using Dapper.Oracle;
using System.Data;
using System.Collections;
using System.Reflection.Metadata;

namespace Dataaccess.Repository
{
    public class EmployeeModuleRepo:ControllerBase
    {



        private readonly DataContext _datacontext;
        private readonly EmployeeModel _employeemodel;
        public EmployeeModuleRepo(DataContext datacontext, EmployeeModel employeemodel)
        {
            _datacontext = datacontext;
            _employeemodel = employeemodel;
        }

        public string GetNameRepo(string name)
        {
            string res = "my name is" + name;
            return res;
        }

        /* [HttpGet("GetRepoQuery1",Name ="GetRepoQuery1")]
         public async Task<IActionResult> GetRepoQuery1()
         {
             try

             {
                 using var connection = _datacontext.CreateConnection();
                 string query = "Select * from emp_434561";
                 var res = await connection.QueryAsync<EmployeeModel>(query);
                 return Ok(res);
             }
             catch (Exception ex)
             {
                 return StatusCode(500, "Internal server error" +ex.Message);
             }


         }*/

        

        public async Task<IActionResult> GetDetailsRepo1()
        {
            OracleRefCursor result = null;
            var procedureName = "proc_viewempWithOut_May31";
            var parameters = new OracleDynamicParameters();

            parameters.Add("emp_refcur", result, OracleMappingType.RefCursor, System.Data.ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _datacontext.CreateConnection();
            var response = await connection.QueryAsync<EmployeeModel>(
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


        public async Task<IEnumerable<EmployeeModel>> GetDetailsRepo3(string flag,string para1,string para2)
        {
            OracleRefCursor result = null;
            var procedureName="proc_viewempWithflag_May31";
            var parameters = new OracleDynamicParameters();
            parameters.Add("flag", flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", para1, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue2", para2, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("emp_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);


            parameters.BindByName = true;

            using var connection = _datacontext.CreateConnection();

            var response = await connection.QueryAsync<EmployeeModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure

                );
            return response;

        }
    }
}
