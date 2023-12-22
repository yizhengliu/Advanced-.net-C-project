using HRAdministrationAPI;
// reference of the API is made to this assembly to make use of the API
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHRAdministration
{
    public enum EmployeeType 
    { 
        Teacher, 
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            decimal totalSalary = 0;
            List<IEmployee> employees = new List<IEmployee>();
            seedData(employees);
            //foreach (IEmployee employee in employees) 
            //{
            //    totalSalary += employee.Salary;
            //}
            //Console.WriteLine($"Total Annual Salaries (including bonus): {totalSalary} ");
            Console.WriteLine($"Total Annual Salaries (including bonus): {employees.Sum(e => e.Salary)} ");
            Console.ReadKey();
        }

        public static void seedData(List<IEmployee> employees) {
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Bob", "Fisher", 40000);
            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Jenny", "Thomas", 40000);
            IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Branda", "Mullins", 50000);
            IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Devlin", "Brown", 60000);
            IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "Damien", "Jones", 80000);
            employees.Add(teacher1);
            employees.Add(teacher2);
            employees.Add(headOfDepartment);
            employees.Add(deputyHeadMaster); 
            employees.Add(headMaster);
            //IEmployee teacher1 = new Teacher
            //{
            //    Id = 1,
            //    FirstName = "Bob",
            //    LastName = "Fisher",
            //    Salary = 40000
            //};

            //employees.Add(teacher1);

            //IEmployee teacher2 = new Teacher
            //{
            //    Id = 2,
            //    FirstName = "Jenny",
            //    LastName = "Thomas",
            //    Salary = 40000
            //};

            //employees.Add(teacher2);
            //IEmployee headOfDepartment = new HeadOfDepartment
            //{
            //    Id = 3,
            //    FirstName = "Branda",
            //    LastName = "Mullins",
            //    Salary = 50000
            //};
            //employees.Add(headOfDepartment);
            //IEmployee deputyHeadMaster = new DeputyHeadMaster
            //{
            //    Id= 4,
            //    FirstName ="Devlin",
            //    LastName = "Brown",
            //    Salary = 60000
            //};
            //employees.Add (deputyHeadMaster);
            //IEmployee headMaster = new HeadMaster
            //{
            //    Id = 5,
            //    FirstName = "Damien",
            //    LastName = "Jones",
            //    Salary = 80000
            //};
            //employees.Add(headMaster);
        }
    }

    public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }
    }

    public class HeadOfDepartment : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }
    }

    public class DeputyHeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }
    }

    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }
    }

    public static class EmployeeFactory 
    {
        public static IEmployee GetEmployeeInstance(EmployeeType empolyeeType, int id, string firstName, string lastName, decimal salary) 
        {
            IEmployee empolyee = null;
            switch (empolyeeType) 
            {
                //case EmployeeType.Teacher:
                //    empolyee = new Teacher { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                //    break;
                //case EmployeeType.HeadOfDepartment:
                //    empolyee = new HeadOfDepartment { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                //    break;
                //case EmployeeType.DeputyHeadMaster:
                //    empolyee = new DeputyHeadMaster { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                //    break;
                //case EmployeeType.HeadMaster:
                //    empolyee = new HeadMaster { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                //    break;
                //default:
                //    Console.WriteLine("undefined empolyee type");
                //    break;

                case EmployeeType.Teacher:
                    empolyee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    break;
                case EmployeeType.HeadOfDepartment:
                    empolyee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                    break;
                case EmployeeType.DeputyHeadMaster:
                    empolyee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                    break;
                case EmployeeType.HeadMaster:
                    empolyee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                    break;
                default:
                    Console.WriteLine("undefined empolyee type");
                    break;
            }
            if (empolyee != null)
            {
                empolyee.Id = id;
                empolyee.FirstName = firstName;
                empolyee.LastName = lastName;
                empolyee.Salary = salary;
            }
            else
                throw new NullReferenceException();
            return empolyee;
        }
    }
}
