using Employeess.Model;
using Employeess.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Repository
{
    public class SalaryRepository : ISalaryRepository
    {
        public async Task<List<Salary>> GetAllSalariesAsync()
        {
            List<Salary> salaries = new List<Salary>();

            string connectionString = @"Server = DESKTOP-PK6EEMJ\SQLEXPRESS; Database = master; Trusted_Connection = True;";
            string sql = "SELECT * FROM Salary";

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                SqlDataReader salaryReader = await sqlCommand.ExecuteReaderAsync();

                while (await salaryReader.ReadAsync())
                {
                    salaries.Add(new Salary(
                        Int32.Parse(salaryReader[0].ToString()),
                        Int32.Parse(salaryReader[1].ToString())
                        ));
                }

                salaryReader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return salaries;
        }
        public async Task<Salary> GetSalaryByIdAsync(int id)
        {
            string connString = @"Server = DESKTOP-PK6EEMJ\SQLEXPRESS; Database = master; Trusted_Connection = True;";
            string sql = "SELECT * FROM Salary WHERE ID = " + id.ToString();

            SqlConnection conn = new SqlConnection(connString);

            Salary salary = new Salary();

            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                SqlDataReader salaryReader = await sqlCommand.ExecuteReaderAsync();

                while (await salaryReader.ReadAsync())
                {
                    salary = new Salary(
                        Int32.Parse(salaryReader[0].ToString()),
                        Int32.Parse(salaryReader[1].ToString())
                    );
                }

                salaryReader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return salary;
        }
        public async Task<bool> AddNewSalaryAsync(Salary salary)
        {
            string connString = @"Server = DESKTOP-PK6EEMJ\SQLEXPRESS; Database = master; Trusted_Connection = True;";
            string sql = "INSERT INTO Salary (ID, amount) VALUES (@id, @amount)";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(sql, conn);

                sqlCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").Value = salary.Id;
                sqlCommand.Parameters.Add("@amount", SqlDbType.VarChar, 20, "amount").Value = salary.Amount;
        
                await sqlCommand.ExecuteNonQueryAsync();

                conn.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteSalaryByIdAsync(int id)
        {
            string connString = @"Server = DESKTOP-PK6EEMJ\SQLEXPRESS; Database = master; Trusted_Connection = True;";
            string sql = "DELETE FROM Salary WHERE ID = @ID";

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
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateSalaryByIdAsync(int id, Salary salary)
        {
            string connString = @"Server = DESKTOP-PK6EEMJ\SQLEXPRESS; Database = master; Trusted_Connection = True;";
            string sql = "UPDATE Salary SET ID = @id, Amount = @amount";
            string get = "SELECT * FROM Salary";

            SqlConnection conn = new SqlConnection(connString);

            SqlDataAdapter adapter = new SqlDataAdapter(get, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Salary");

            DataTable dt = ds.Tables["Salary"];
            dt.Rows[0]["Id"] = "Id";
            dt.Rows[1]["amount"] = "amount";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                adapter.UpdateCommand = cmd;
                adapter.Update(ds, "Salary");

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
