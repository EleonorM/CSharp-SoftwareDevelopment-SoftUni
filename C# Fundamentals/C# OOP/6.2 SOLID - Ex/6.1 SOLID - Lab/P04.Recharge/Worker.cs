namespace P04.Recharge
{
    public abstract class Worker :IEmployee, IWorker, ISleeper, IRechargeable
    {
        private int workingHours;

        public Worker(string id): base(id)
        {
        }

        public void Work(int hours)
        {
            this.workingHours += hours;
        }

        public abstract void Sleep();

        public abstract void Recharge();
    }
}