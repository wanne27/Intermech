namespace Task2
{
    public static class Person
    {
        [Obsolete("Warning")]
        public static void ShowInfo()
        {
            Console.WriteLine("Show information");
        }

        [Obsolete("Error", true)]
        public static void ShowError()
        {
            Console.WriteLine("Show error");
        }
    }
}
