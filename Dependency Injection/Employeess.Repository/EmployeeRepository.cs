using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employeess.Model;
using Employeess.Repository.Common;

namespace Employeess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        string connString = @"Server = DESKTOP-PK6EEMJ\SQLEXPRESS; Database = master; Trusted_Connection = True;";
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            List<Employee> employees = new List<Employee>();
            string sql = "SELECT * FROM Employee";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                SqlDataReader employeeReader = await sqlCommand.ExecuteReaderAsync();

                while (await employeeReader.ReadAsync())
                {
                    employees.Add(new Employee(
                        Int32.Parse(employeeReader[0].ToString()),
                        employeeReader[1].ToString(),
                        employeeReader[2].ToString(),
                        DateTime.Parse(employeeReader[3].ToString()),
                        employeeReader[4].ToString(),
                        DateTime.Parse(employeeReader[5].ToString())
                        ));
                }

                employeeReader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return employees;
        }
        public async Task<Employee> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM Employee WHERE ID = " + id.ToString();

            SqlConnection conn = new SqlConnection(connString);

            Employee employee = new Employee();

            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                SqlDataReader employeeReader = await sqlCommand.ExecuteReaderAsync();

                while (await employeeReader.ReadAsync())
                {
                    employee = new Employee(
                        Int32.Parse(employeeReader[0].ToString()),
                        employeeReader[1].ToString(),
                        employeeReader[2].ToString(),
                        DateTime.Parse(employeeReader[3].ToString()),
                        employeeReader[4].ToString(),
                        DateTime.Parse(employeeReader[5].ToString())
                    );
                }

                employeeReader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return employee;
        }
        public async Task<bool> AddNewEmployeeAsync(Employee employee)
        {
            string sql = "INSERT INTO Employee (ID, first_name, last_name, birth_date, gender, hire_date) VALUES (@id, @first_name, @last_name, @birth_date, @gender, @hire_date)";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(sql, conn);

                sqlCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").Value = employee.Id;
                sqlCommand.Parameters.Add("@first_name", SqlDbType.VarChar, 20, "first_name").Value = employee.FirstName;
                sqlCommand.Parameters.Add("@last_name", SqlDbType.VarChar, 20, "last_name").Value = employee.LastName;
                sqlCommand.Parameters.Add("@birth_date", SqlDbType.Date, 10, "birth_date").Value = employee.BirthDate;
                sqlCommand.Parameters.Add("@gender", SqlDbType.Char, 1, "gender").Value = employee.Gender;
                sqlCommand.Parameters.Add("@hire_date", SqlDbType.Date, 10, "hire_date").Value = employee.HireDate;

                await sqlCommand.ExecuteNonQueryAsync();

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteEmployeeByIdAsync(int id)
        { 
            string sql = "DELETE FROM Employee WHERE ID = " + id.ToString();

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                await cmd.ExecuteNonQueryAsync();

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateEmployeeByIdAsync(int id, Employee employee)
        {
            string sql = "UPDATE Employee SET first_name = @first_name, last_name = @last_name, birth_date = @birth_date, gender = @gender, hire_date = @hire_date WHERE ID = @ID";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.Parameters.Add("@ID", SqlDbType.Int, 4, "ID").Value = id;
                sqlCommand.Parameters.Add("@first_name", SqlDbType.VarChar, 20, "first_name").Value = employee.FirstName;
                sqlCommand.Parameters.Add("@last_name", SqlDbType.VarChar, 20, "last_name").Value = employee.LastName;
                sqlCommand.Parameters.Add("@birth_date", SqlDbType.Date, 10, "birth_date").Value = employee.BirthDate;
                sqlCommand.Parameters.Add("@gender", SqlDbType.Char, 1, "gender").Value = employee.Gender;
                sqlCommand.Parameters.Add("@hire_date", SqlDbType.Date, 10, "hire_date").Value = employee.HireDate;

                await sqlCommand.ExecuteNonQueryAsync();

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            return true;
        }
    }
}
