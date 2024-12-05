namespace Task
{
    /// <summary>
    /// Класс который хранит дату, текст, категорию.
    /// Используется при сериализации в json
    /// </summary>
    public class DayEventData
    {
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
    }
}
