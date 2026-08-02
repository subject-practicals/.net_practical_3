using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_2
{
    internal class Program
    {
        class Employee
        {
            public int empId;
            public string name;
            public string designation;
            public int salary;
            public bool fullTime;
            public int leaves;
        }

        interface IPayroll
        {
            void CalculateSalary();
        }

        class GetDetails : Employee
        {
            public void GetEmployeeDetails()
            {
                Console.WriteLine("---------------Enter Employee Details---------------");
                Console.WriteLine("Enter Employee ID: ");
                empId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee Name: ");
                name = Console.ReadLine();
                Console.WriteLine("Enter Employee Designation: ");
                designation = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary: ");
                salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Is Employee Full Time? (true/false): ");
                fullTime = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine("Enter Employee Leaves: ");
                leaves = Convert.ToInt32(Console.ReadLine());
            }
        }

        class DisplayDetails : GetDetails, IPayroll
        {

            public void CalculateSalary()
            {
                double da = 0, hra = 0, ma = 0, pf = 0;
                double totalSalary = 0;
                int salaryCut = 0;

                if (salary >= 500000)
                {
                    da = salary * 0.05;
                    hra = salary * 0.02;
                    ma = salary * 0.03;
                    pf = 20000;
                }
                else
                {
                    da = salary * 0.03;
                    hra = salary * 0.01;
                    ma = salary * 0.02;
                    pf = 10000;
                }

                totalSalary = (salary + da + hra + ma) - pf;

                if (leaves > 10)
                {
                    salaryCut = (leaves - 10) * 1000;
                }

                totalSalary -= salaryCut;

                Console.WriteLine("\n--------- Salary Details ---------");
                Console.WriteLine("Basic Salary : " + salary);
                Console.WriteLine("DA           : " + da);
                Console.WriteLine("HRA          : " + hra);
                Console.WriteLine("MA           : " + ma);
                Console.WriteLine("PF           : " + pf);
                Console.WriteLine("Total Leaves: " + leaves);
                Console.WriteLine("Salary Cut: $" + salaryCut);
                Console.WriteLine("Net Salary   : " + totalSalary);
            }
            public void DisplayEmployeeDetails()
            {
                Console.WriteLine("---------------Employee Details---------------");
                Console.WriteLine("Employee ID: " + empId);
                Console.WriteLine("Employee Name: " + name);
                Console.WriteLine("Employee Designation: " + designation);
                Console.WriteLine("Employee Salary: " + salary);

                if (fullTime)
                    Console.WriteLine("Employee is Full Time");
                else
                    Console.WriteLine("Employee is Part Time");

            }
        }
        static void Main(string[] args)
        {
            DisplayDetails employee = new DisplayDetails();

            employee.GetEmployeeDetails();
            employee.DisplayEmployeeDetails();
            IPayroll payroll = employee;
            payroll.CalculateSalary();
        }
    }
}