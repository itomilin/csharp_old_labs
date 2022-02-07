using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            const string FILE_NAME = "AYlogfile.txt"; // имя файла
            AYLog logger = new AYLog(FILE_NAME); // Создадим объект для ведения лога

            try
            {
                logger.AddNewEntry(EnvironmentInfo.AYDiskInfo());
                // Необходимо указать полный путь до файла или относительный если в debug
                logger.AddNewEntry(EnvironmentInfo.AYFileInfo(".\\AYlogfile.txt"));
                // Необходимо указать полный путь до существующей директории в файловой системе
                // или относительный если debug
                logger.AddNewEntry(EnvironmentInfo.AYDirInfo(@"D:\testDir"));
                // Также, путь до директории
                logger.AddNewEntry(AYFileManager.AYReadInspectDrive("D:\\testDir"));
                // путь до директории, маска для поиска файлов *.txt *.* * итд
                logger.AddNewEntry(AYFileManager.AYCreateDirAndArchive("D:\\testDir", "*.xlsx"));

                // подсчет записей
                logger.AddNewEntry(CountEntries(FILE_NAME));

                // удалить все старше часа
                logger.AddNewEntry(RemovePartialInfo(FILE_NAME));

                // Путь до лога, дата в формате, как ниже
                logger.AddNewEntry(PrintInfo(FILE_NAME, "03.01.2021"));

                // Первый параметр дата начала, дата конца, все что между нас интересует
                logger.AddNewEntry(PrintInfo(FILE_NAME,
                    "02.01.2021 20:08:46",
                    "02.01.2021 21:10:46"));

                logger.AddNewEntry(PrintInfoByKey(FILE_NAME,
                    "AYReadInspectDrive")); // PrintInfo CountEntries итд
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// 9 ПУНКТ   
   
        /// <summary>
        /// Считаем количество записей, на основе ключа DATE
        /// </summary>
        /// <param name="fileName">имя файла</param>
        private static string CountEntries(string fileName)
        {
            string countInfo = "\nCALL: CountEntries\n";
            // Открываем поток и читаем в него файл
            using (var sr = new StreamReader(fileName))
            {
                int counter = 0; // счетчик
                while (!sr.EndOfStream) // пока не достигнем конца прочтенного файла
                {
                    // если DATA, тогда считается записью в файле
                    if (sr.ReadLine().Contains("DATE")) // если в строке встречается слово DATA
                    {
                        ++counter; // увеличиваем счетчик
                    }
                }
                Console.WriteLine($"Количество записей в файле {fileName}: {counter}");
            }
            return countInfo;
        }

        /// <summary>
        /// Удаляем все записи старше 60 минут
        /// </summary>
        /// <param name="fileName">имя файла</param>
        private static string RemovePartialInfo(string fileName)
        {
            string removeInfo = "\nCALL: RemovePartialInfo\n";
            var currentDate = DateTime.Now; // Получим текущую дату
            // Прочтем в список, для удобства
            List<string> lines = File.ReadAllLines(fileName).ToList();
            for (int i = 0; i < lines.Count; ++i)
            {
                if (lines[i].Contains("DATE")) // если встречаем дату
                {
                    // Извлекаем из строки дату и парсим в формат
                    // для удобной работы
                    var entryDate = DateTime.Parse(lines[i].Substring(5));

                    // Если разница между двумя датами (текущей и та, что в файле)
                    // Больше 60 минут, удаляем такую запись
                    if ((currentDate - entryDate).TotalMinutes > 60)
                    {
                        int countToRemove = 0;
                        int j;
                        for (j = i; j < lines.Count; ++j)
                        {
                            // считаем количество строк до следующего раздилеля
                            if (lines[j].Length != 0 && lines[j][0] == '=')
                            {
                                lines.RemoveAt(0); // удаляем верхнюю границу разделителя
                                lines.RemoveRange(i - 1, j); // удаляем диапазон от верхнего до нижнего разделителя 
                                break;
                            }
                            else
                            {
                                ++countToRemove;
                            }
                        }
                        i = 0; // сбрасываем i
                    }
                }
            }
            // перезаписываем файл
            File.WriteAllLines(fileName, lines.ToArray());
            Console.WriteLine($"Файл {fileName} очищен от записей созданных старше часа.");
            return removeInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">Путь до файла с логом</param>
        /// <param name="setDate">Дата в формате 24.12.2020</param>
        private static string PrintInfo(string fileName, string setDate)
        {
            string printInfo = "\nCALL: PrintInfo\n";
            Console.WriteLine($"Поиск по дате {setDate}");
            var findDate = DateTime.Parse(setDate); // Получим заданную дату
            // Прочтем файл в список, для удобства
            List<string> lines = File.ReadAllLines(fileName).ToList();
            for (int i = 0; i < lines.Count; ++i)
            {
                if (lines[i].Contains("DATE")) // если встречаем дату
                {
                    // Извлекаем из строки дату и парсим в формат
                    // для удобной работы
                    var entryDate = DateTime.Parse(lines[i].Substring(5));

                    // сравниваем по дате
                    if (findDate.ToShortDateString() == entryDate.ToShortDateString())
                    {
                        int j;
                        for (j = i; j < lines.Count; ++j)
                        {
                            // находим слово CALL
                            if (lines[j].Length != 0 && lines[j].Contains("CALL"))
                            {
                                // выводим информацию о дате и действии
                                Console.WriteLine(lines[i] + " | " + lines[j]);
                                break;
                            }
                        }
                        i = j; // Увеличиваем i
                    }
                }
            }
            return printInfo;
        }

        // Перегрузим предыдущий метод
        private static string PrintInfo(string fileName, string setDate1, string setDate2)
        {
            string printInfo = "\nCALL: PrintInfo\n";
            Console.WriteLine($"Поиск по диапазону ${setDate1} <= data < {setDate2}");
            var findDate1 = DateTime.Parse(setDate1); // Получим заданную дату
            var findDate2 = DateTime.Parse(setDate2); // Получим заданную дату
            // Прочтем файл в список, для удобства
            List<string> lines = File.ReadAllLines(fileName).ToList();
            for (int i = 0; i < lines.Count; ++i)
            {
                if (lines[i].Contains("DATE")) // если встречаем дату
                {
                    // Извлекаем из строки дату и парсим в формат
                    // для удобной работы
                    var entryDate = DateTime.Parse(lines[i].Substring(5));

                    // сравниваем по дате
                    if (findDate1 <= entryDate &&
                        findDate2 >= entryDate)
                    {
                        int j;
                        for (j = i; j < lines.Count; ++j)
                        {
                            // находим слово CALL
                            if (lines[j].Length != 0 && lines[j].Contains("CALL"))
                            {
                                // выводим информацию о дате и действии
                                Console.WriteLine(lines[i] + " | " + lines[j]);
                                break;
                            }
                        }
                        i = j; // Увеличиваем i
                    }
                }
            }
            return printInfo;
        }

        /// <summary>
        /// Поиск по ключу, указываем имя метода из класса, если такой найденно в файле,
        /// то печатаем дату события и повторно имя вызываемого метода через разделитель
        /// </summary>
        /// <param name="fileName">Путь до файла</param>
        /// <param name="key">Ключ, необходимо указать название метода</param>
        private static string PrintInfoByKey(string fileName, string key)
        {
            string printInfoByKey = "\nCALL: PrintInfoByKey\n";
            Console.WriteLine($"Поиск по ключевому слову {key}");
            List<string> lines = File.ReadAllLines(fileName).ToList();
            for (int i = 0; i < lines.Count; ++i)
            {
                if (lines[i].Contains(key))
                {
                    Console.WriteLine(lines[i] + " | " + lines[i - 2]);                    
                }
            }

            return printInfoByKey;
        }
        //////////////////////
    }
}
