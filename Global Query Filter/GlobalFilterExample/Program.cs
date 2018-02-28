using GlobalFilterExample.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalFilterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EntityModelContext context = new EntityModelContext())
            {
                Console.WriteLine("---------------With Global Query Filters---------------");
                var data = context.Employees.ToList();
                foreach (var d in data)
                {
                    Console.WriteLine("{0}\t{1}", d.Id, d.Name);
                }
                Console.WriteLine("---------------Ignore Global Query Filters---------------");

                var data1 = context.Employees
                    .IgnoreQueryFilters().ToList();
                foreach (var d in data1)
                {
                    Console.WriteLine("{0}\t{1}", d.Id, d.Name);
                }

                Console.ReadLine();

            }
        }
    }
}
