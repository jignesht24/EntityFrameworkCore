using Microsoft.EntityFrameworkCore;
using TableSplittingExample.Model;
using System;
using System.Linq;

namespace TableSplittingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Select();
            //Insert();
            //Update();
            Delete();
        }

        public static void Select()
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                Console.WriteLine("------------- Employee Entity -------------");
                var data1 = context.Employees.ToList();
                Console.ReadLine();

                Console.Clear();

                Console.WriteLine("------------- EmployeeDetail Entity -------------");
                var data2 = context.EmployeeDetails.ToList();

                Console.ReadLine();

                Console.Clear();

                Console.WriteLine("------------- Both Entities together -------------");
                var data3 = context.Employees.Include(p => p.EmployeeDetail).ToList();

                Console.ReadLine();
                Console.Clear();

            }
        }
        public static void Insert()
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                Employee emp = new Employee
                {
                    Id = 5,
                    Name = "Vishal",
                    IsDeleted = false,
                    EmployeeDetail = new EmployeeDetail { EmailAddress = "vishal@gmail.com", MobileNumber = "895648552" }
                };

                context.Add(emp);
                context.SaveChanges();
            }
            Console.ReadLine();
            Console.Clear();
        }
        public static void Update()
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                Employee emp = context.Employees.Include(p => p.EmployeeDetail).Where(p => p.Id == 5).FirstOrDefault();
                emp.Name = "Meera";
                emp.EmployeeDetail.EmailAddress = "Meera@gmail.com";
                context.SaveChanges();
            }
            Console.ReadLine();
        }

        public static void Delete()
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                Employee emp = context.Employees.Include(p => p.EmployeeDetail).Where(p => p.Id == 5).FirstOrDefault();
                context.Entry<Employee>(emp).State = EntityState.Deleted;
                context.SaveChanges();
            }
            Console.ReadLine();
        }
    }
}
