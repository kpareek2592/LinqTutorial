using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1,2,3,4,5,6,7,8,9,10};

            List<Employee> employee = new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "Aman"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Rahul"
                }
            };

            IEnumerable<Employee> query = from emp in employee
                                          where emp.Id == 1
                                          select emp;

            foreach (var item in query)
            {
                Console.WriteLine($"Name: {item.Name} and Id: {item.Id}");
            }

            IQueryable<Employee> query1 = employee.AsQueryable().Where(x => x.Id == 1);
            foreach (var item in query1)
            {
                Console.WriteLine($"Name: {item.Name} and Id: {item.Id}");
            }


            Console.ReadLine();
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
