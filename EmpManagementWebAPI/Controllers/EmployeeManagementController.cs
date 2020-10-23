using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EmpManagementBL.implementation;
using EmpManagementML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {
        private readonly IEmpManagementBusinessLayer empManagementBusinessLayer;

        public EmployeeManagementController(IEmpManagementBusinessLayer empManagementBusinessLayer)
        {
            this.empManagementBusinessLayer = empManagementBusinessLayer;
        }

        [Route("addemployee")]
        [HttpPost]
        public ActionResult AddEmployee([FromBody]EmployeeDetails employeeDetails)
        {
            var result = this.empManagementBusinessLayer.AddEmployee(employeeDetails);
            try
            {
                if (result != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Employee Added Successfully", result));
                }
                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound,"Employee Not Found", result));
            }
            catch(Exception ex)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest,"",result));
            }
        }
    }
}
