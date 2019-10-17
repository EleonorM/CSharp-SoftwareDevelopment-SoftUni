namespace P04.Recharge
{
    public class Employee : IEmployee, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public  void Sleep()
        {
            // sleep...
        }
        
    }
}
