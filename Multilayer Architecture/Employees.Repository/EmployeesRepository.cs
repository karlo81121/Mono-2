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
            string sql = "DELETE FROM Employee WHERE ID = @ID";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public bool UpdateEmployeeById(int id, Employee.Model.Employee employee)
        {
            string connString = @"Server = DESKTOP-PK6EEMJ\SQLEXPRESS; Database = master; Trusted_Connection = True;";
            string sql = "UPDATE Employee SET ID = @id, @first_name = first_name, @last_name = last_name, @birth_date = birth_date, @gender = gender, @hire_date = hire_date";
            string get = "SELECT * FROM Employee";

            SqlConnection conn = new SqlConnection(connString);

            SqlDataAdapter adapter = new SqlDataAdapter(get, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Employee");

            DataTable dt = ds.Tables["Emplyee"];
            dt.Rows[0]["ID"] = "ID";
            dt.Rows[1]["fist_name"] = "first_name";
            dt.Rows[2]["last_name"] = "last_name";
            dt.Rows[3]["birth_date"] = "birth_date";
            dt.Rows[4]["gender"] = "gender";
            dt.Rows[5]["hire_date"] = "hire_date";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                adapter.UpdateCommand = cmd;
                adapter.Update(ds, "Employee");

                conn.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
