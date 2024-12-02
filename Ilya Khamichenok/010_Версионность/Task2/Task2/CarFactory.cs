namespace Task2
{
    public class CarFactory : Factory
    {
        public override void FinishTime()
        {
            Console.WriteLine("Завод машин заканчивает работу в 18:00");
        }

        public override void StartTime()
        {
            Console.WriteLine("Завод машин начинает работу в 9:00");
        }
    }
}
