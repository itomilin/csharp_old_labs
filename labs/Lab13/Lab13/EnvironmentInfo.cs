using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class EnvironmentInfo
    {
        /// <summary>
        /// Метод вывода информации о дисках, которые найдены в системе
        /// и имеют объем.
        /// </summary>
        /// <returns></returns>
        public static string AYDiskInfo()
        {
            // Получим список дисков
            DriveInfo[] drives = DriveInfo.GetDrives();
            string diskInfo = "\nCALL: AYDiskInfo\n";

            // Переберем каждый диск
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady) // Например, если дисковод, то он может быть пуст
                {
                    diskInfo += $"\nDriveName: {drive.Name}\n" + // имя диска
                        $"AvailableSpace: {drive.AvailableFreeSpace / 1024 / 1024} MB\n" + // свободно в мб
                        $"FileSystem: {drive.DriveFormat}\n" + // файловая система
                        $"TotalSize: {drive.TotalSize / 1024 / 1024 / 1024} GB\n" + // всего в gb
                        $"Label: {drive.VolumeLabel}\n"; // метка
                }  
            }
            return diskInfo;
        }

        /// <summary>
        /// Метод, который получает информацию о конкретном файле.
        /// </summary>
        /// <param name="fileName">Путь до конкретного файла в файловой системе</param>
        /// <returns>Строка с информацией</returns>
        public static string AYFileInfo(string fileName)
        {
            // Получим информацию о файле по полному пути до файла
            FileInfo file = new FileInfo(fileName);
            string fileInfo = "\nCALL: AYFileInfo\n";

            if (!file.Exists) // Если файл не существует
            {
                // Просто возвратим, что было вызвано и добавим
                return fileInfo + $"\n!!{fileName} NOT FOUND!!\n"; 
            }

            // Если файл есть, тогда получим информацию о нем.
            fileInfo += $"\nFullPath: {file.FullName}\n" +
                $"Size: {file.Length} byte\n" +
                $"Extension: {file.Extension}\n" +
                $"Name: {file.Name}\n" +
                $"CreationTime: {file.CreationTime}\n";

            return fileInfo;
        }

        /// <summary>
        /// Метод для выводе информации об указанной директории
        /// </summary>
        /// <param name="dirName">Имя директории</param>
        /// <returns></returns>
        public static string AYDirInfo(string dirName)
        {
            // Получим информацию о файле по полному пути до файла
            DirectoryInfo dir = new DirectoryInfo(dirName);
            string dirInfo = "\nCALL: AYDirInfo\n";

            if (!dir.Exists) // Если файл не существует
            {
                // Просто возвратим, что было вызвано и добавим
                return dirInfo + $"\n!!{dirName} NOT FOUND!!\n";
            }

            // Если директория есть, тогда получим информацию
            dirInfo += $"\nCountOfFiles (.txt): " +
                /** зададим маску *.txt, чтобы искал только txt, иначе все,
                 * что не директория, будет считаться файлом
                 * также укажим, чтобы искал, только в текущей директории без рекурсии
                 */
                $"{dir.GetFiles("*.txt", SearchOption.TopDirectoryOnly).Length}\n" +
                // Путь
                $"FullPath: {dir.FullName}\n" +
                // Имя
                $"Name: {dir.Name}\n" +
                // Время создания
                $"CreationTime: {dir.CreationTime}\n" +
                // КОличество директорий в текущей
                $"CountOfSubdir: {dir.GetDirectories().Length}\n" +
                // Вернем список имен директорий, которые на уровень выше
                $"ListOfParentDirs:\n" +
                $"{string.Join("\n", dir.Parent.GetDirectories().ToList())}\n";

            return dirInfo;
        }
    }
}
