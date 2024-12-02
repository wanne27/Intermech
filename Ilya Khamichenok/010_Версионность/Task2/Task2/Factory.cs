namespace Task2
{
    public abstract class Factory
    {
        public void Work()
        {
            StartTime();
            LunchTime();
            FinishTime();
        }

        public abstract void StartTime();

        public abstract void FinishTime();

        public virtual void LunchTime()
        {
            Console.WriteLine("Время обеда с 12:00 до 13:00");
        }
    }
}
