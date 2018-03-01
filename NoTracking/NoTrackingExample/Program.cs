using Microsoft.EntityFrameworkCore;
using NoTrackingExample.Model;
using System;
using System.Linq;

namespace NoTrackingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            UsingExtensionMethod();
            UsingContextLevelNoTrack();
            OtherExample();
        }

        public static void UsingExtensionMethod()
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                var data = context.Employees
                            .AsNoTracking().ToList();
                foreach (var d in data)
                {
                    Console.WriteLine("{0}\t{1}", d.Id, d.Name);
                }

                var data1 = context.Employees
                                .Where(p => p.Id > 2)
                                .AsNoTracking().ToList();

                foreach (var d in data)
                {
                    Console.WriteLine("{0}\t{1}", d.Id, d.Name);
                }

                Console.ReadLine();

            }
        }

        public static void UsingContextLevelNoTrack()
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
               
                var data = context.Employees.ToList();
                foreach (var d in data)
                {
                    Console.WriteLine("{0}\t{1}", d.Id, d.Name);
                }
                
                Console.ReadLine();
            }
        }

        public static void OtherExample()
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                //Automatically no track applied
                var data1 = context.Employees.Select(emp => new
                {
                    id = emp.Id,
                    name = emp.Name,
                }).ToList();

                //Entity framework track Employee entity type
                var data2 = context.Employees.Select(emp => new
                {
                    id = emp.Id,
                    Employee = emp

                }).ToList();
            }
        }
    }
}
