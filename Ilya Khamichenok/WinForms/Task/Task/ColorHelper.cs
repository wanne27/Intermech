namespace Task
{
    /// <summary>
    /// static класс с методом поиска цвета по категории
    /// </summary>
    public static class ColorHelper
    {
        /// <summary>
        /// Метод, который возвращает цвет в зависимости от категории события
        /// </summary>
        /// <param name="category">Категория события</param>
        /// <returns>Color</returns>
        public static Color GetColorByCategory(string category)
        {
            switch (category)
            {
                case "Учеба":
                    return Color.Red;
                case "Работа":
                    return Color.Blue;
                case "Спорт":
                    return Color.Orange;
            }

            return default(Color);
        }
    }
}
