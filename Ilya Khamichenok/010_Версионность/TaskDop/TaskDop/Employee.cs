namespace TaskDop
{
    public abstract class Employee
    {
        public void DoWork()
        {
            CoreDoWork();
        }

        protected abstract void CoreDoWork();
    }
}
