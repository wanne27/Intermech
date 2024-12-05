namespace Task2
{
    /// <summary>
    /// Имитирует работу с БД, содержит 4 метода
    /// Connection и Disconnection для имитации подключения и отключения БД
    /// ConnectionPrint, DisconnectionPrint возвращают строку с сообщением о подключении к БД или отключении
    /// </summary>
    public class ConnectionDB
    {
        /// <summary>
        /// Метод имитирует подключение к Бд
        /// </summary>
        /// <param name="cancellationToken"> токен отмены, который будет передавать в метод ConnectionPrint</param>
        /// <returns>Строка</returns>
        public async Task<string> Connection(CancellationToken cancellationToken)
        {
            await Task.Delay(new Random().Next(3000, 5000));
            return ConnectionPrint("Подключен к БД", cancellationToken);
        }
        /// <summary>
        ///  Метод имитирует отключение от БД
        /// </summary>
        /// <returns>Строка</returns>
        public async Task<string> Disconnection()
        {
            await Task.Delay(new Random().Next(1000, 3000));
            return DisconnectionPrint("Отключен от БД");
        }
        /// <summary>
        /// Метод возвращает строку сигнализирующую о подключении к БД
        /// </summary>
        /// <param name="str">Строка, которую надо вернуть</param>
        /// <param name="cancellationToken">Токен отмены, в случае отмены, будет пробрасывать ошибку наверх</param>
        /// <returns>Строка</returns>
        public string ConnectionPrint(string str, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return str;
        }
        /// <summary>
        /// Метод возвращает строку сигнализирующую об отключении БД
        /// </summary>
        /// <param name="str">Строка, которую надо вернуть</param>
        /// <returns>Строка</returns>
        public string DisconnectionPrint(string str)
        {
            return str;
        }
    }
}
