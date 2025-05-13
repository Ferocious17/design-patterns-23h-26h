namespace DesignPatterns.Adapter
{
    public class Employee
    {
        public Employee(decimal salary)
        {
            Salary = salary;
        }

        public decimal Salary { get; }
    }

    public class PresidentOfTheBoard
    {
        public PresidentOfTheBoard(decimal bonus)
        {
            Bonus = bonus;
        }

        public decimal Bonus { get; }
    }

    public class EmployeeAdapter : Employee
    {
        public EmployeeAdapter(PresidentOfTheBoard president)
            : base(president.Bonus)
        {
        }
    }
}
