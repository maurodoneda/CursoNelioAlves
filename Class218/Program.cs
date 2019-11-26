using System;
using System.Collections.Generic;
using Class218.Entities;
using System.Globalization;
using System.Linq;
using System.IO;


namespace Class218
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            double salaryToCompare = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);

                    list.Add(new Employee(name, email, salary));
                }
            }

            var emails = list.Where(p => p.Salary > salaryToCompare).OrderBy(p => p.Email).Select(p => p.Email);
            foreach(string email in emails)
            {
                Console.WriteLine(email);
            }

            var salaryList = list.Where(p => p.Name.StartsWith('M')).Select(p => p.Salary);
                      
            Console.Write("Sum of salary of people whose name starts with 'M': " + salaryList.Sum());
            






        }
    }
}
