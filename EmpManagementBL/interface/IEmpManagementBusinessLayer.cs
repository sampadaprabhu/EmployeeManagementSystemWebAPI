using EmpManagementML;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpManagementBL.implementation
{
    public interface IEmpManagementBusinessLayer
    {
        bool AddEmployee(EmployeeDetails employeeDetails);
        bool UpdateEmployee(EmpManagementModelLayer empManagementModelLayer);
        bool DeleteEmployee(int EmpID);
        List<EmpManagementModelLayer> GetAllEmployees();
    }
}
