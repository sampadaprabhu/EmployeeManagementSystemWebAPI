using EmpManagementML;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpManagementRL.implementation
{
    public interface IEmpManagementRepositoryLayer
    {
        bool AddEmployee(EmpManagementModelLayer empManagementModelLayer);
    }
}
