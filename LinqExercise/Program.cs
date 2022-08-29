using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            Console.WriteLine($"Sum:");
            Console.WriteLine($"------------------------");
            //TODO: Print the Sum of numbers
            var sum = numbers.Sum();
            Console.WriteLine(sum);

            Console.WriteLine();

            Console.WriteLine($"Average:");
            Console.WriteLine($"------------------------");
            //TODO: Print the Average of numbers
            var average = numbers.Average();
            Console.WriteLine(average);

            Console.WriteLine();

            Console.WriteLine($"Ascending:");
            Console.WriteLine($"------------------------");
            //TODO: Order numbers in ascending order and print to the console
            var ascending = numbers.OrderBy(x => x);
            foreach (var item in ascending)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine($"Descending:");
            Console.WriteLine($"------------------------");
            //TODO: Order numbers in decsending order adn print to the console
            var descending = numbers.OrderByDescending(x => x);
            foreach (var item in descending)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine($"Numbers greater than six:");
            Console.WriteLine($"------------------------");
            //TODO: Print to the console only the numbers greater than 6
            numbers.Where(num => num > 6).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            Console.WriteLine($"Four numbers ascending:");
            Console.WriteLine($"------------------------");
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            foreach (var item in ascending.Take(4))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine($"With my age, descending order.");
            Console.WriteLine($"------------------------");
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 25;
            foreach (var item in numbers.OrderByDescending(x => x))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            Console.WriteLine($"Employees with first name C or S, ascending:");
            //TODO: Print all the employees' FullName properties to the console
            //only if their FirstName starts with a C OR an S
            //and order this in ascending order by FirstName.
            var filtered = employees.Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S')).OrderBy(x => x.FirstName);
            foreach (var item in filtered)
            {
                Console.WriteLine(item.FullName);
            }

            Console.WriteLine();

            Console.WriteLine($"Employees over 26:");
            //TODO: Print all the employees' FullName and Age
            //who are over the age 26 to the console
            //and order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach (var employee in overTwentySix)
            {
                Console.WriteLine($"Age: {employee.Age} Name: {employee.FullName}");
            }

            Console.WriteLine();

            Console.WriteLine($"YOE Sum:");
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var yoeOverThirtyFive = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            var sumOfYOE = yoeOverThirtyFive.Sum(x => x.YearsOfExperience);

            var avgYOE = yoeOverThirtyFive.Average(x => x.YearsOfExperience);

            Console.WriteLine(sumOfYOE);
            Console.WriteLine();
            Console.WriteLine($"YOE Average");
            Console.WriteLine(avgYOE);

            Console.WriteLine();

            Console.WriteLine($"Adding new employee to the list:");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Jane", "Doe", 1, 10)).ToList();
            foreach (var item in employees)
            {
                Console.WriteLine($"Name: {item.FullName} YOE: {item.YearsOfExperience} Age: {item.Age}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
