using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApplication.EmployeeCRUD
{
    
    public class MainDisplay
    {
        public  void Display()
        {
            Console.WriteLine(" GREETINGS FROM ASPIRE SYSTEMS\n1.Add Employee Details \n " +
                              "2.Read a specific Employee \n " +
                              "3.Update Employee Details \n " +
                              "4.Display Employee Details \n " +
                              "5.Delete Employee Details \n " +
                              "6.Exit \n\n" + "Enter the corresponding number ");
            int option = Convert.ToInt32(Console.ReadLine());
            MainDisplay mainDisplay = new MainDisplay();          
            mainDisplay.SwitchFun(option);


        }
        public void SwitchFun(int option)
        {
            MainDisplay mainDisplay = new MainDisplay();
            CrudOperation crudOperation = new CrudOperation();
            switch (option)
            {
                case 1:
                    Console.WriteLine("How many Employee Details do you want to add:");
                    int count;
                    CheckEmployeeCount();
                    void CheckEmployeeCount()
                    {
                        count = Convert.ToInt32(Console.ReadLine());
                        if (count <= 10)
                            for (int i = 1; i <= count; i++)
                                crudOperation.InsertToTable();
                        else
                        {
                            Console.WriteLine("Invalid input, You can Add only upto 10 employees at a time \nEnter a valid input:");
                            CheckEmployeeCount();
                        }
                    }
                    Console.WriteLine("\nDetails of All " + count + " Employees are sucessfully added\n");
                    Display();
                    break;
                case 2:
                    crudOperation.DisplayRow();
                    Console.WriteLine("\n");
                    Display();
                    break;
                case 3:
                    crudOperation.UpdateTable();
                    Console.WriteLine("\n");
                    Display();
                    break;
                case 4:
                    crudOperation.DisplayTable();
                    Console.WriteLine("\n");
                    Display();
                    break;
                case 5:
                    crudOperation.DeleteDetails();
                    Console.WriteLine("\n");
                    Display();
                    break;
                case 6:
                    Console.WriteLine("Press Enter to Exit");
                    break;
                default:
                    Console.WriteLine("Invaild input.Enter Numbers from 1 to 6 only");
                    Display();
                    break;
            }
        }
    }
}
