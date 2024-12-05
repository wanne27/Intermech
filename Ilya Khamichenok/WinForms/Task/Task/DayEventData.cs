namespace Task
{
    /// <summary>
    /// Класс который хранит дату, текст, категорию.
    /// Используется при сериализации в json
    /// </summary>
    public class DayEventData
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Текст заметки или события
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Категория события
        /// </summary>
        public string Category { get; set; } = string.Empty;
    }
}
