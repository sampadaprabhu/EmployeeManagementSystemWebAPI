using EmpManagementBL.implementation;
using EmpManagementML;
using EmpManagementRL.implementation;
using System;
using System.Collections.Generic;

namespace EmpManagementBL
{
    public class EmpManagementBusinessLayer : IEmpManagementBusinessLayer
    {
        private readonly IEmpManagementRepositoryLayer empManagementRepositoryLayer; 

        public EmpManagementBusinessLayer(IEmpManagementRepositoryLayer empManagementRepositoryLayer)
        {
            this.empManagementRepositoryLayer = empManagementRepositoryLayer;
        }
        public bool AddEmployee(EmployeeDetails employeeDetails)
        {
            try
            {
                return this.empManagementRepositoryLayer.AddEmployee(employeeDetails);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateEmployee(EmpManagementModelLayer empManagementModelLayer)
        {
            try
            {
                return this.empManagementRepositoryLayer.UpdateEmployee(empManagementModelLayer);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteEmployee(int EmpID)
        {
            try
            {
                return this.empManagementRepositoryLayer.DeleteEmployee(EmpID);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EmpManagementModelLayer> GetAllEmployees()
        {
            try
            {
                return this.empManagementRepositoryLayer.GetAllEmployees();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
