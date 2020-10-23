﻿using System;
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
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest,"",ex.Message));
            }
        }

        [Route("updatemployee")]
        [HttpPost]
        public ActionResult UpdateEmployee([FromBody] EmpManagementModelLayer empManagementModelLayer)
        {
            var result = this.empManagementBusinessLayer.UpdateEmployee(empManagementModelLayer);
            try
            {
                if (result != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Employee Updated Successfully", result));
                }
                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Employee Not Updated", result));
            }

            catch(Exception ex)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "", ex.Message));
            }
        }

        [Route("deleteemployee")]
        [HttpDelete]
        public ActionResult DeleteEmployee(int EmpID)
        {
            var result = this.empManagementBusinessLayer.DeleteEmployee(EmpID);
            try
            {
                if (result != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Employee Deleted Successfully", result));
                }
                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Employee Not Deleted", result));
            }
            catch (Exception ex)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "", ex.Message));
            }
        }

        [Route("getalllist")]
        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            var result = this.empManagementBusinessLayer.GetAllEmployees();
            try
            {
                if (result != null)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "All Employee Data Found", result));
                }
                return this.NotFound(new ResponseEntity(HttpStatusCode.NotFound, "Employee Data Not Found", result));
            }
            catch (Exception ex)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "", ex.Message));
            }
        }
    }
}
