using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBase
{
    class Options
    {
        public void Create(List<Employee> sourceList, List<Employee> listToShow)
        {
            int id;
            string firstName;
            string lastName;
            byte age;
            string passport;
            string phone;
            string position;
            string employmentDate;
            double salary;

            Console.WriteLine("Введите Id сотрудника:");
            string str = Console.ReadLine();
            id = Convert.ToInt32(str);

            Console.WriteLine("Введите имя сотрудника:");
            str = Console.ReadLine();
            firstName = str;

            Console.WriteLine("Введите фамилию сотрудника:");
            str = Console.ReadLine();
            lastName = str;

            Console.WriteLine("Введите возвраст сотрудника:");
            str = Console.ReadLine();
            age = Convert.ToByte(str);

            Console.WriteLine("Введите номер паспорта сотрудника:");
            str = Console.ReadLine();
            passport = str;

            Console.WriteLine("Введите телефон сотрудника:");
            str = Console.ReadLine();
            phone = str;

            Console.WriteLine("Введите должность сотрудника:");
            str = Console.ReadLine();
            position = str;

            Console.WriteLine("Введите дату приема на работу:");
            str = Console.ReadLine();
            employmentDate = str;

            Console.WriteLine("Введите зарплату сотрудника:");
            str = Console.ReadLine();
            salary = Convert.ToDouble(str);

            Employee createdEmployee = new Employee(id, firstName, lastName, age, passport, phone, position, employmentDate, salary);

            sourceList.Add(createdEmployee);
            listToShow.Add(createdEmployee);
        }

        public void DeleteById(List<Employee> sourceList, List<Employee> listToShow, int id)
        {
            sourceList.Remove(sourceList.Single(employeeToDelete => employeeToDelete.Id == id));
            listToShow.Remove(listToShow.Single(employeeToDelete => employeeToDelete.Id == id));
        }

        public void GetById(List<Employee> sourceList, List<Employee> listToShow, int id)
        {
            listToShow.Clear();
            listToShow.Add(sourceList.Single(employee => employee.Id == id));
        }

        public void GetAll(List<Employee> sourceList, List<Employee> listToShow)
        {
            listToShow.Clear();
            listToShow.AddRange(sourceList);
        }

        public void SortById(List<Employee> sourceList, List<Employee> listToShow)
        {
            IEnumerable<Employee> res = sourceList.OrderBy(e => e.Id).ToList();
            listToShow.Clear();
            listToShow.AddRange(res);
        }
    }
}
