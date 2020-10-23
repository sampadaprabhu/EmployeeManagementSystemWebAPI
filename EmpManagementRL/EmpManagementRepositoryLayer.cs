using EmpManagementML;
using EmpManagementRL.implementation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmpManagementRL
{
    public class EmpManagementRepositoryLayer :IEmpManagementRepositoryLayer
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;
        private readonly IConfiguration configuration;

        public EmpManagementRepositoryLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeManagement").Value;
            this.connection = new SqlConnection(this.connectionString);
        }

        public bool AddEmployee(EmployeeDetails employeeDetails)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SPAddEmployeeData", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@EmpID", empManagementModelLayer.EmpID);
                    command.Parameters.AddWithValue("@FirstName", employeeDetails.FirstName);
                    command.Parameters.AddWithValue("@LastName", employeeDetails.LastName);
                    command.Parameters.AddWithValue("@EmailID", employeeDetails.EmailID);
                    command.Parameters.AddWithValue("@PhoneNumber", employeeDetails.PhoneNumber);
                    command.Parameters.AddWithValue("@DepartmentID", employeeDetails.DepartmentID);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public bool UpdateEmployee(EmpManagementModelLayer empManagementModelLayer)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SPUpdateEmployeeData", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", empManagementModelLayer.EmpID);
                    command.Parameters.AddWithValue("@FirstName", empManagementModelLayer.FirstName);
                    command.Parameters.AddWithValue("@LastName", empManagementModelLayer.LastName);
                    command.Parameters.AddWithValue("@EmailID", empManagementModelLayer.EmailID);
                    command.Parameters.AddWithValue("@PhoneNumber", empManagementModelLayer.PhoneNumber);
                    command.Parameters.AddWithValue("@DepartmentID", empManagementModelLayer.DepartmentID);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public bool DeleteEmployee(int EmpID)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SPDeleteEmployeeData", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpID", EmpID);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public List<EmpManagementModelLayer> GetAllEmployees()
        {
            try
            {
                List<EmpManagementModelLayer> getAllData = new List<EmpManagementModelLayer>();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpGetAllEmployees", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    this.connection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            EmpManagementModelLayer empManagementModelLayer = new EmpManagementModelLayer();
                            empManagementModelLayer.EmpID = Convert.ToInt32(sqlDataReader["EmpID"]);
                            empManagementModelLayer.FirstName = sqlDataReader["FirstName"].ToString();
                            empManagementModelLayer.LastName = sqlDataReader["LastName"].ToString();
                            empManagementModelLayer.EmailID = sqlDataReader["EmailID"].ToString();
                            empManagementModelLayer.PhoneNumber = sqlDataReader["PhoneNumber"].ToString();
                            empManagementModelLayer.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                            getAllData.Add(empManagementModelLayer);
                        }
                        return getAllData;
                    }
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}