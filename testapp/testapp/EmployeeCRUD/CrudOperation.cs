/*Employee form validation
 * this  program gets input from user ,vadidates it, displays in console
 * Author- Madujith M A
 * DOC 16/10/2021
 * Reviewed by- Jaya and Akshaya
 * Modified on 09/11/2021 */
using System;
using System.Linq;
using System.Data.SqlClient;
namespace EmployeeApplication.EmployeeCRUD
{
    public class CrudOperation
    {

        string ConectionString = @"Data Source=jith\mydatabase;Initial Catalog=jith_test;Integrated Security=True";
        EmployeeDetails employeeDetails = new EmployeeDetails();
        public void InsertToTable()
        {
            SqlConnection sqlConnection = null;
            try
            {
                
                sqlConnection = new SqlConnection(ConectionString);

                SqlCommand sqlCommand = new SqlCommand("insert into EmployeeTable([EmployeeID],[EmployeeName],[EmployeeEmail],[EmployeePhoneNumber],[DateOFBirth],[DateOfJoining])values('"+ employeeDetails.AddEmployeeID() + "','"+employeeDetails.AddEmployeeName()+"','"+ employeeDetails.AddEmployeeEmail()+ "','"+ employeeDetails.AddEmployeePhoneNumber() + "','" + employeeDetails.AddEmployeeDateOfBirth() + "','" + employeeDetails.AddEmployeeDateOfJoinining()+ "')", sqlConnection);
                // Opening Connection  
                sqlConnection.Open();
                // Executing the SQL query  
                sqlCommand.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Record Inserted Successfully\n");
            }
            catch (Exception exception)
            {
                Console.WriteLine("OOPs, something went wrong." + exception);
            }
            // Closing the connection  
            finally
            {
                sqlConnection.Close();
            }
        }
        public void DisplayTable()
        {
            SqlConnection sqlConnection = null;
            try
            {
                // Creating Connection
                sqlConnection = new SqlConnection(ConectionString);
                // writing sql query  
                SqlCommand sqlCommand = new SqlCommand("select * from EmployeeTable", sqlConnection);
                // Opening Connection  
                sqlConnection.Open();
                // Executing the SQL query  
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Console.WriteLine(sqlDataReader["EmployeeID"] + "  " + sqlDataReader["EmployeeName"] + "  " + sqlDataReader["EmployeeEmail"] + "  " + sqlDataReader["EmployeePhoneNumber"] + "  " + sqlDataReader["DateOFBirth"] + "  " + sqlDataReader["DateOfJoining"]);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("OOPs, something went wrong." + exception);
            }
            // Closing the connection  
            finally
            {
                sqlConnection.Close();
            }
        }
        string NewValue;
        string ColumnName;
        string ConditionColoumn = "EmployeeID";
        String Condition;
        public void UpdateTable()
        {
            SqlConnection sqlConnection = null;
            
            
            try
            {
                //Condition = employeeDetails.AddEmployeeID();
                Console.WriteLine("\nEnter the corresponding Number of  Column Name that you want to update\n" +
                                    "ColoumnNames:\n" +                                     
                                    "\n1[EmployeeName]\n2[EmployeeEmail]\n3[EmployeePhoneNumber]\n4[DateOFBirth]\n5[DateOfJoining]" +
                                    "\n6[EmployeeID]");
                
                int SelectColoumn = Convert.ToInt32( Console.ReadLine());
                ChooseColumnName(SelectColoumn);               
                sqlConnection = new SqlConnection(ConectionString);
                SqlCommand sqlCommand = new SqlCommand("UPDATE EmployeeTable SET [" + ColumnName + "]='" + NewValue + "'WHERE ["+ConditionColoumn+"]='" + Condition + "';",sqlConnection);
                // Opening Connection  
                sqlConnection.Open();
                // Executing the SQL query  
                sqlCommand.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Record updated Successfully\n");
            }
            catch (Exception exception)
            {
                Console.WriteLine("OOPs, something went wrong." + exception);
            }
            // Closing the connection  
            ////finally
            {
                sqlConnection.Close();
            }
            void ChooseColumnName(int Column)
            {
                switch (Column)
                {
                    case 1:
                        {
                            Condition = employeeDetails.AddEmployeeID();
                            ColumnName = "EmployeeName";
                            NewValue = employeeDetails.AddEmployeeName();
                            break;
                        }
                    case 2:
                        {
                            Condition = employeeDetails.AddEmployeeID();
                            ColumnName = "EmployeeEmail";
                            NewValue = employeeDetails.AddEmployeeEmail();
                            break;
                        }
                    case 3:
                        {
                            Condition = employeeDetails.AddEmployeeID();
                            ColumnName = "EmployeePhoneNumber";
                            NewValue = employeeDetails.AddEmployeePhoneNumber();
                            break;
                        }
                    case 4:
                        {
                            Condition = employeeDetails.AddEmployeeID();
                            ColumnName = "DateOfBirth";
                            NewValue = employeeDetails.AddEmployeeDateOfBirth();
                            break;
                        }
                    case 5:
                        {
                            Condition = employeeDetails.AddEmployeeID();
                            ColumnName = "DateOfJoining";
                            NewValue = employeeDetails.AddEmployeeDateOfJoinining();
                            break;
                        }
                    case 6:
                        {
                            Condition = employeeDetails.AddEmployeePhoneNumber();
                            ColumnName = "EmployeeID";
                            NewValue = employeeDetails.AddEmployeeID();
                            break;
                        }
                    default:
                        Console.WriteLine("Invaild input.Enter Numbers from 1 to 6 only");
                        break;
                } 
                      
                        

                        
                
            }

            
        }
        public void DeleteDetails()
        {
            SqlConnection sqlConnection = null;
            try
            {
                Console.WriteLine("Enter EmployeeID of the Row you want to delete");
                Condition = employeeDetails.AddEmployeeID();
                sqlConnection = new SqlConnection(ConectionString);

                SqlCommand sqlCommand = new SqlCommand("Delete From EmployeeTable where EmployeeId='"+Condition+"';", sqlConnection);
                // Opening Connection  
                sqlConnection.Open();
                // Executing the SQL query  
                sqlCommand.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Record with EmployeeID  "+Condition+" is Deleted Successfully\n");
            }
            catch (Exception exception)
            {
                Console.WriteLine("OOPs, something went wrong." + exception);
            }
            // Closing the connection  
            finally
            {
                sqlConnection.Close();
            }
        }
        public void DisplayRow()
        {
            SqlConnection sqlConnection = null;
            try
            {
                Condition = employeeDetails.AddEmployeeID();
                // Creating Connection
                sqlConnection = new SqlConnection(ConectionString);
                // writing sql query  
                SqlCommand sqlCommand = new SqlCommand("select * from EmployeeTable where EmployeeID='"+Condition+"';", sqlConnection);
                // Opening Connection  
                sqlConnection.Open();
                // Executing the SQL query  
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Console.WriteLine(sqlDataReader["EmployeeID"] + "  " + sqlDataReader["EmployeeName"] + "  " + sqlDataReader["EmployeeEmail"] + "  " + sqlDataReader["EmployeePhoneNumber"] + "  " + sqlDataReader["DateOFBirth"] + "  " + sqlDataReader["DateOfJoining"]);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("OOPs, something went wrong." + exception);
            }
            // Closing the connection  
            finally
            {
                sqlConnection.Close();
            }
        }
        public static void Main()
        {
            MainDisplay mainDisplay = new MainDisplay();
            mainDisplay.Display();
        }
 
    }
}

