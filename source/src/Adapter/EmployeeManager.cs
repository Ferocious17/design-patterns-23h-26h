namespace DesignPatterns.Adapter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EmployeeManager
    {
        private readonly List<Employee> _employees = [];

        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Remove(Employee employee)
        {
            _employees.Remove(employee);
        }

        public decimal PaySalaries()
        {
            return _employees.Sum(x => x.Salary);
        }
    }
}
