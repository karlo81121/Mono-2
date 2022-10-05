using Employees.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Employee> employees = new List<Employee>();
            List<Salary> salaries = new List<Salary>();

            Console.WriteLine("Getting Connection ...");

            string connString = @"Server = DESKTOP-PK6EEMJ\SQLEXPRESS; Database = master; Trusted_Connection = True;";

            string employeeSql = "SELECT * FROM Employee";
            string salarySql = "SELECT * FROM Salary";

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                Console.WriteLine("Openning Connection ...");
                conn.Open();
                Console.WriteLine("Connection successful!");

                Console.WriteLine();

                SqlCommand employee = new SqlCommand(employeeSql, conn);
                SqlDataReader employeeReader = employee.ExecuteReader();

                Console.WriteLine("Employees: ");
                Console.WriteLine();

                while (employeeReader.Read())
                {
                    Console.WriteLine(employeeReader[0].ToString() + '\t'
                                      + employeeReader[1].ToString() + '\t' + '\t'
                                      + employeeReader[2].ToString() + '\t' + '\t'
                                      + DateTime.Parse(employeeReader[3].ToString()).ToString("d") + '\t'
                                      + employeeReader[4].ToString() + '\t'
                                      + DateTime.Parse(employeeReader[5].ToString()).ToString("d") + '\t'
                                     );
                }

                employeeReader.Close();

                Console.WriteLine();

                Console.WriteLine("Salaries: ");
                Console.WriteLine();

                SqlCommand salary = new SqlCommand(salarySql, conn);
                SqlDataReader salariesReader = salary.ExecuteReader();

                while (salariesReader.Read())
                {
                    Console.WriteLine(salariesReader[0].ToString() + '\t'
                                      + salariesReader[1].ToString() + '\t'
                                      );
                }

                salariesReader.Close();

                SqlDataAdapter employeeAdapter = new SqlDataAdapter();
                DataSet employeeDs = new DataSet();
                SqlCommand employeeCommand = new SqlCommand(employeeSql, conn);

                employeeAdapter.SelectCommand = employeeCommand;
                employeeAdapter.Fill(employeeDs);

                Console.WriteLine();
                Console.WriteLine("Using SqlDataAdapter...");
                Console.WriteLine();
                Console.WriteLine("Employees: ");
                Console.WriteLine();

                for(int i = 0; i <= employeeDs.Tables[0].Rows.Count - 1; i++)
                {
                    Console.WriteLine(employeeDs.Tables[0].Rows[i].ItemArray[0] + "\t" +
                                      employeeDs.Tables[0].Rows[i].ItemArray[1] + "\t" + '\t' +
                                      employeeDs.Tables[0].Rows[i].ItemArray[2] + "\t" + '\t' +
                                      DateTime.Parse(employeeDs.Tables[0].Rows[i].ItemArray[3].ToString()).ToString("d") + "\t" +
                                      employeeDs.Tables[0].Rows[i].ItemArray[4] + "\t" +
                                      DateTime.Parse(employeeDs.Tables[0].Rows[i].ItemArray[5].ToString()).ToString("d")
                                      );
                }

                Console.WriteLine();
                Console.WriteLine("Using SqlDataAdapter...");
                Console.WriteLine();
                Console.WriteLine("Salaries: ");
                Console.WriteLine();

                SqlDataAdapter salaryAdapter = new SqlDataAdapter();
                DataSet salaryDs = new DataSet();
                SqlCommand salaryCommand = new SqlCommand(salarySql, conn);

                salaryAdapter.SelectCommand = salaryCommand;
                salaryAdapter.Fill(salaryDs);

                for(int i = 0; i < salaryDs.Tables[0].Rows.Count - 1; i++)
                {
                    Console.WriteLine(salaryDs.Tables[0].Rows[i].ItemArray[0] + "\t" +
                                      salaryDs.Tables[0].Rows[i].ItemArray[1]
                                      );
                }

                conn.Close();

                Console.WriteLine();
                Console.WriteLine("Connection closed!");

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}