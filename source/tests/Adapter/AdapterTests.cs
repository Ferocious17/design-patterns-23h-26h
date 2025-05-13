namespace DesignPatterns.Tests.Adapter
{
    using DesignPatterns.Adapter;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AdapterTests
    {
        public void Add()
        {
            var employeeManager = new EmployeeManager();
            
            employeeManager.Add(new Employee(60_000));
            employeeManager.Add(new EmployeeAdapter(new PresidentOfTheBoard(1_000_000)));

        }
    }
}
