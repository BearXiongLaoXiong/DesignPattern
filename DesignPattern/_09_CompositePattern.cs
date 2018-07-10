using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._09_Composite
{
    [DataContract(Name = "组合模式")]
    public class _09_CompositePattern
    {
        public static void Run()
        {
            Console.WriteLine(typeof(_09_CompositePattern).GetClassName());

            Employee ceo = new Employee("John", "CEO", 30000);
            Employee headSales = new Employee("Robert", "Head Sales", 20000);
            Employee headMarketing = new Employee("Michel", "Head Marketing", 20000);

            Employee clerk1 = new Employee("Laura", "Marketing", 10000);
            Employee clerk2 = new Employee("Bob", "Marketing", 10000);

            Employee salesExecutive1 = new Employee("Richard", "Sales", 10000);
            Employee salesExecutive2 = new Employee("Rob", "Sales", 10000);

            ceo.Add(headSales);
            ceo.Add(headMarketing);

            headSales.Add(salesExecutive1);
            headSales.Add(salesExecutive2);

            headMarketing.Add(clerk1);
            headMarketing.Add(clerk2);

            Console.WriteLine(ceo.ToStringMessage());

            foreach (var head in ceo.GetSubordinates())
            {
                Console.WriteLine(head.ToStringMessage());
                foreach (var employee in head.GetSubordinates())
                {
                    Console.WriteLine(employee.ToStringMessage());
                }
            }

            Console.WriteLine();
        }
    }

    public class Employee
    {
        private string _name;
        private string _dept;
        private int _salary;
        private readonly List<Employee> _subordinates;

        public Employee(string name, string dept, int salary)
        {
            _name = name;
            _dept = dept;
            _salary = salary;
            _subordinates = new List<Employee>();
        }

        public void Add(Employee employee) => _subordinates.Add(employee);

        public void Remove(Employee employee) => _subordinates.Remove(employee);

        public List<Employee> GetSubordinates() => _subordinates;

        public string ToStringMessage() => $"Employee :[ Name:{ _name}, dept:{_dept }, salary:{_salary}]";
    }
}
