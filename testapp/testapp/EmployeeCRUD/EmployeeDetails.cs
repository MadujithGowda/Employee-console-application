using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace EmployeeApplication.EmployeeCRUD
{
    public class EmployeeDetails
    {
        string EmployeeID;
        string EmployeeName;
        string EmployeeEmail;
        string EmployeePhoneNumber;
        DateTime DateOfBirth;
        DateTime DateOfJoining;
        RegexValidation regex = new RegexValidation();

        public string AddEmployeeName()
        {
            Console.WriteLine("Enter Employee Name ");
            EmployeeName = Console.ReadLine();
            bool validnameResult = regex.ValidateEmployeeName(EmployeeName);
            if (validnameResult != true)
            {
                Console.WriteLine("Invalid Name,Please enter atleast 3 characters (Starting Letter Should be caps)");
                AddEmployeeName();
            }
            return EmployeeName;
        }
        public string AddEmployeeID()
        {
            Console.WriteLine("Enter Employee ID");
            EmployeeID = Console.ReadLine();

            bool ValidEmployeeIDResult = regex.ValidateID(EmployeeID);
            if ((EmployeeID == "ACE0000") || (ValidEmployeeIDResult != true))
            {

                Console.WriteLine("Invalid ID,Employee Id should start with 'ACE' Followed by four digits example-ACE1234 ");
                AddEmployeeID();
            }
            return EmployeeID;
        }
        public string AddEmployeeEmail()
        {
            Console.WriteLine("Enter Email");
            EmployeeEmail = Console.ReadLine();

            bool validEmailResult = regex.ValidateEmail(EmployeeEmail);
            if (validEmailResult != true)
            {
                Console.WriteLine("Invalid Email, Enter a proper format of Email example :loreum@gmail.com,magnum@aspiresys.com ");
                AddEmployeeEmail();
            }
            return EmployeeEmail;
        }
        public string AddEmployeePhoneNumber()
        {
            Console.WriteLine("Enter 10 digit PhoneNumber");
            EmployeePhoneNumber=Console.ReadLine();

            bool ValidPhoneNumberResult = regex.ValidatePhoneNumber(EmployeePhoneNumber);
            if (ValidPhoneNumberResult != true)
            {
                Console.WriteLine("Invalid Phone Number, Phone number should start with 6,7,8,9 and should have 10 digits in total");
                AddEmployeePhoneNumber();
            }
            return EmployeePhoneNumber;
        }
        public string AddEmployeeDateOfBirth()
        {
            try
            {
                Console.WriteLine("Enter Date of Birth (format:DD/MM/YYYY)");
                DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            }
            catch (SystemException)
            {
                SystemException systemException = new SystemException();
                Console.WriteLine("Invalid Date, enter date in (format:DD/MM/YYYY)");
                AddEmployeeDateOfBirth();
            }
            return DateOfBirth.ToString("yyyy-MM-dd");
        }
        public string AddEmployeeDateOfJoinining()
        {
            try
            {
                Console.WriteLine("Enter Date of Joining(format:DD/MM/YYYY)");
                DateOfJoining = Convert.ToDateTime(Console.ReadLine());
                int JoiningAge = DateOfJoining.Year - DateOfBirth.Year;
                if (JoiningAge < 18 ) 
                {
                    Console.WriteLine("Employee age must be atleast 18");
                    AddEmployeeDateOfJoinining();
                }
                if (JoiningAge > 60)
                {
                    Console.WriteLine("Employee age must be below 60");
                    AddEmployeeDateOfJoinining();
                }
                if (DateOfJoining > DateTime.Now)
                {
                    Console.WriteLine("Future Dates are not allowe enter a date within"+DateTime.Now);
                    AddEmployeeDateOfJoinining();
                }
            }
            catch (SystemException)
            {
                SystemException systemException = new SystemException();
                Console.WriteLine("Invalid Date,enter date in (format:DD/MM/YYYY)");
                AddEmployeeDateOfJoinining();
            }
            return DateOfJoining.ToString("yyyy-MM-dd"); 
        }
            
           
    }

}
