using Employeess.Model;
using Employeess.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employeess.Common;

namespace Employeess.Repository
{
    public class SalaryRepository : ISalaryRepository
    {
        string connString = @"Server = DESKTOP-PK6EEMJ\SQLEXPRESS; Database = master; Trusted_Connection = True;";
        public async Task<List<Salary>> GetAllSalariesAsync(Paging paging, Sorting sorting, SalaryFiltering filtering)
        {
            List<Salary> salaries = new List<Salary>();

            StringBuilder stringBuilder = new StringBuilder();

            int offset = (paging.PageNumber - 1) * paging.PageSize;

            stringBuilder.Append("SELECT * FROM Salary ");
            stringBuilder.Append($"WHERE Amount LIKE '{filtering.Amount}%'");
            stringBuilder.Append($"ORDER BY {sorting.SortBy} {sorting.SortOrder}");
            stringBuilder.Append(" OFFSET " + offset + " ROWS FETCH NEXT " + paging.PageSize + " ROWS ONLY");


            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(stringBuilder.ToString(), conn);

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
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteSalaryByIdAsync(int id)
        {
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
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateSalaryByIdAsync(int id, Salary salary)
        {
            string sql = "UPDATE Salary SET ID = @ID, Amount = @Amount WHERE ID = @ID";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.Parameters.Add("@ID", SqlDbType.Int, 4, "ID").Value = id;
                sqlCommand.Parameters.Add("@Amount", SqlDbType.VarChar, 20, "first_name").Value = salary.Amount;

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
