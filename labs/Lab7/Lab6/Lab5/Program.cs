using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    // Разделим класс program, на несколько
    // Перенесем метод тестирования в другой файл.
    partial class Program
    {
        static void Main(string[] args)
        {
            // Создадим блок try-catch-finally
            // В участках кода выбрасываются исключения, после того, как они будут
            // выброшены, в зависимости от типа исключения обработка будет просходить
            // в блоках catch
            // Обработаем несколько из огромного кол-ва возможных исключений, включая свои.

            // ЧТобы выводить конкретное место в коде, где было вызвано исключение
            // сообщение об исключении, воспользуемся свойсвами класса Exception
            // message stacktrace
            try
            {
                try
                {
                    Test2();
                }
                catch (EmptyObjectsException ex) // Собственное исключение
                {
                    // Вызываем наш метод, который что-то делает.
                    // В данном случае, печатает ошибку на консоль и завершает работу приложения.
                    Console.WriteLine($"!!!ERROR!!!\n{ex.Message}\n{ex.StackTrace}");
                    // Вызовем и собственный метод-обработчик, со своей реализацией
                    ex.ExceptionHandler();
                }
                catch (GoodsNameException ex) // Собственное исключение
                {
                    // Вызываем наш метод, который что-то делает.
                    // В данном случае, печатает ошибку на консоль и завершает работу приложения.
                    Console.WriteLine($"!!!ERROR!!!\n{ex.Message}\n{ex.StackTrace}");
                    // Вызовем и собственный метод-обработчик
                    ex.ExceptionHandler("!!ОШИБКА!! Ошибка длины строки.");
                }
                catch (DateException ex) // Еще одно собственное исключение
                {
                    Console.WriteLine(ex.Message);
                    // Задержка консоли
                    Console.ReadKey();
                    // Завершение приложение со статусом 1
                    Environment.Exit(1);
                }
                catch (FormatException ex) // Системное исключение
                {
                    // Печатаем сообщение на консоль информацию
                    Console.WriteLine($"!!!ERROR!!!\n{ex.Message}\n{ex.StackTrace}");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                catch (ArgumentNullException ex) // Системное исключение
                {
                    Console.WriteLine($"!!!ERROR!!!\n{ex.Message}\n{ex.StackTrace}");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                catch (NullReferenceException ex) // Системное исключение
                {
                    Console.WriteLine($"!!!ERROR!!!\n{ex.Message}\n{ex.StackTrace}");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                catch (Exception)
                {
                }
            }
            finally
            {
                try
                {
                    throw new Exception("Finally Exception");
                }
                catch { }
            }
            //Test();
            Console.ReadKey();
        }
    }
}
