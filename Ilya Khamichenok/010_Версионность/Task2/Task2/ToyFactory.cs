namespace Task2
{
    public class ToyFactory : Factory
    {
        public override void FinishTime()
        {
            Console.WriteLine("Завод игрушек заканчивает работу в 17:00");
        }

        public override void StartTime()
        {
            Console.WriteLine("Завод игрушек начинает работу в 8:00");
        }

        public override void LunchTime()
        {
            Console.WriteLine("Время обеда с 13:00 до 14:00");
        }
    }
}
