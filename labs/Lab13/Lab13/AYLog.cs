using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    // 4. Создадим класс для логирования
    class AYLog
    {
        readonly private string _fileName = "";

        // Конструктор принимает имя файла, в который будем писать
        public AYLog(string fileName)
        {
            _fileName = fileName;
        }

        // a. метод добавления новой информации в файл
        public void AddNewEntry(string info)
        {
            string buffer = new string('=', 80) +
                Environment.NewLine + // ограничим линией каждое из действий
                $"DATE: {DateTime.Now}\n" +// Получаем текущее время
                info + // информация о предыдущем действии
                new string('=', 80); 

            // Укажем имя файла лога, разрешим дозапись файла, укажем кодировку
            using (StreamWriter writetext = 
                new StreamWriter(_fileName, true, Encoding.UTF8))
            {
                // пишем буфер в файл
                writetext.WriteLine(buffer);
            }
        }
    }
}
