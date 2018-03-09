using Microsoft.EntityFrameworkCore;
using ShadowProperties.Model;
using System;
using System.Linq;

namespace ShadowProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            Select();
            Select1();
            Insert();
            Update();
        }

        public static void Select()
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                Console.WriteLine("------------- Employee Entity -------------");
                var data1 = context.Employees
                            .OrderBy(b => EF.Property<DateTime>(b, "CreatedDate")).ToList();
                Console.ReadLine();
                Console.Clear();
            }
        }
        public static void Select1()
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                Console.WriteLine("------------- Employee Entity -------------");
                var data1 = (from p in context.Employees
                             select new
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 CreateDate = EF.Property<DateTime>(p, "CreatedDate")
                             }).ToList();

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
                };
                context.Entry(emp).Property("CreatedDate").CurrentValue = DateTime.Now;

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
                Employee emp = context.Employees.Where(p => p.Id == 5).FirstOrDefault();
                emp.Name = "Meera";
                context.Entry(emp).Property("CreatedDate").CurrentValue = DateTime.Now;
                context.SaveChanges();
            }
            Console.ReadLine();
        }

    }
}
