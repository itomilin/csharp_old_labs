using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Lab13
{
    // Пункт 8
    class AYFileManager
    {
        // выполняет все указанные действия из пункта a. 8 задания
        public static string AYReadInspectDrive(string path)
        {
            string inspectInfo = "\nCALL: AYReadInspectDrive\n";
            // Создаем директорию, если существует, то создана не будет
            string newDirName = "AYInspect";
            Directory.CreateDirectory(newDirName);

            // Имя файла для записи
            string newFileName = "AYdirinfo.txt";

            // Создаем объект для конкретного пути
            var dirInfo = new DirectoryInfo(path);
            // открываем поток,пишем в файл, перезаписываем, если есть, кодировка
            using (var sw = new StreamWriter($"{newDirName}\\AYdirinfo.txt", false, Encoding.UTF8))
            {
                try
                {
                    foreach (var entry in dirInfo.EnumerateFileSystemInfos("*",
                SearchOption.AllDirectories))
                    {
                        sw.WriteLine(entry.FullName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR. SKIP file" + ex);
                }
            }

            // Копируем и переименовываем, разрешаем на перезапись вторым параметром
            inspectInfo += $"\nКопируем файл {newDirName}\\AYdirinfo.txt\n" +
                $"в {newDirName}\\copy_{newFileName}";
            File.Copy($"{newDirName}\\AYdirinfo.txt",
                newDirName + "\\copy_" + newFileName, true);


            // Удаляем первоначальный файл
            inspectInfo += $"\nУдаляем файл {newDirName}\\AYdirinfo.txt\n";
            File.Delete($"{newDirName}\\AYdirinfo.txt");
            
            return inspectInfo;
        }

        // 8 задание, пункт b, c
        public static string AYCreateDirAndArchive(string dirPath, string fileMask)
        {
            string inspectInfo = "\nCALL: AYCreateDirAndArchive\n";
            // Создаем директорию, если существует, то создана не будет
            string newDirName = "AYFiles";
            Directory.CreateDirectory(newDirName);
            // Создаем объект для конкретного пути
            var dirInfo = new DirectoryInfo(dirPath);
            try
            {
                foreach (var entry in dirInfo.EnumerateFileSystemInfos(fileMask,
            SearchOption.AllDirectories))
                {
                    // копируем файлы в директорию, разрешаем перезапись, если существует
                    File.Copy(entry.FullName, $"{newDirName}\\{entry.Name}",true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR. SKIP file" + ex);
            }
            // Перемещаем директорию в другую
            Directory.Move($".\\{newDirName}", $".\\AYInspect\\{newDirName}");

            string zipPath = $".\\AYInspect\\{newDirName}.zip"; // путь до создания архива
            string extractPath = ".\\ARCHIVE\\"; // куда распакуем

            // Создадим архив
            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
            {
                inspectInfo += "\nФайлы для архива:\n";
                // Перебираем все файлы для создания архива
                foreach (var item in Directory.GetFiles($".\\AYInspect\\{newDirName}"))
                {
                    // помещаем файлы в архив
                    archive.CreateEntryFromFile(item, item);
                    inspectInfo += item + Environment.NewLine;
                }

                // разархивируем
                inspectInfo += $"\nРазархивировали файл в {extractPath}\n";
                archive.ExtractToDirectory(extractPath);
            }

            Directory.Delete($".\\AYInspect\\{newDirName}", true); // удалим директорию с файлами для архива
            inspectInfo += $"\nУдалим директорию .\\AYInspect\\{newDirName}\n";


            return inspectInfo;
        }
    }
}
