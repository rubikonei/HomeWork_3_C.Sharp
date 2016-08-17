using System;

namespace DataBase
{
    [Serializable]
    public class Employee
    {
        public Employee() { }

        public Employee(int id, string firstName, string lastName, byte age, string passport, string phone,
            string position, string employmentDate, double salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Passport = passport;
            Phone = phone;
            Position = position;
            EmploymentDate = employmentDate;
            Salary = salary;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string EmploymentDate { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return "ID: " + Id + ", Имя: " + FirstName + ", Фамилия: " + LastName +
                ", возвраст: " + Age + ", паспорт: " + Passport +
                ", должность: " + Position + ", дата приема: " + EmploymentDate +
                ", зарплата: " + Salary;
        }
    }
}
