using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            if (Capacity > data.Count)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name) 
        {
            Employee employee = data.FirstOrDefault(e => e.Name == name);
            if (employee == null)
            {
                return false;
            }

            data.Remove(employee);
            return true;
        }

        public Employee GetOldestEmployee() 
        {
            return data.OrderByDescending(e => e.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name) 
        {
            Employee employee = data.FirstOrDefault(e => e.Name == name);
            return employee;
        }

        public string Report() 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
