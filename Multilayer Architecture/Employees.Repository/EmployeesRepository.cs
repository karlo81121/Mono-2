using Employee.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Repository
{
    public class EmployeesRepository
    {
        public List<Employee.Model.Employee> GetAllEmployees()
        {
            List<Employee.Model.Employee> employees = new List<Employee.Model.Employee>();

            string connectionString = @"Server = DESKTOP-PK6EEMJ\SQLEXPRESS; Database = master; Trusted_Connection = True;";
            string sql = "SELECT * FROM Employee";

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                SqlDataReader employeeReader = sqlCommand.ExecuteReader();

                while (employeeReader.Read())
                {
                    employees.Add(new Employee.Model.Employee(
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
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return employees;
        }
        public Employee.Model.Employee GetById(int id)
        {
            string connString = @"Server = DESKTOP-PK6EEMJ\SQLEXPRESS; Database = master; Trusted_Connection = True;";
            string sql = "SELECT * FROM Employee WHERE ID = " + id.ToString();

            SqlConnection conn = new SqlConnection(connString);

            Employee.Model.Employee employee = new Employee.Model.Employee();

            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                SqlDataReader employeeReader = sqlCommand.ExecuteReader();

                while (employeeReader.Read())
                {
                    employee = new Employee.Model.Employee(
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
        public bool AddNewEmployee(Employee.Model.Employee employee)
        {
            string connString = @"Server = DESKTOP-PK6EEMJ\SQLEXPRESS; Database = master; Trusted_Connection = True;";
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

                sqlCommand.ExecuteNonQuery();

                conn.Close();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public bool DeleteEmployeeById(int id)
        {
            string connString = @"Server = DESKTOP-PK6EEMJ\SQLEXPRESS; Database = master; Trusted_Connection = True;";
            string sql = "DELETE FROM Employee WHERE ID = @Id";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();

                SqlDataAdapter employeeAdapter = new SqlDataAdapter();
                SqlParameter parameter = new SqlParameter();
                SqlCommand command = new SqlCommand(sql, conn);

                parameter = command.Parameters.Add("@id", SqlDbType.Int, 4, "id");
                parameter.SourceVersion = DataRowVersion.Original;

                employeeAdapter.DeleteCommand = command;

                conn.Close();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
