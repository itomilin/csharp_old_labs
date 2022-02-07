using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Строка, которую будем модифицировать.
                string baseString = " d f.df.df.sf.";
                Console.WriteLine($"Исходная строка: {baseString}");
                
                // Используем func, в отличии от action имеет тип возвращаемого значения
                // определяем его 4 параметром, для данного примера.
                Func<string, char, char, string> HandleString = (param1, param2, param3) =>
                {
                    param1 = StringHandler.RemoveDots(param1);
                    Console.WriteLine($"Удалили точки: {param1}");
                    param1 = StringHandler.RemoveSpaces(param1);
                    Console.WriteLine($"Удалили пробелы: {param1}");
                    param1 = StringHandler.AddSymbolToEnd(param1, param3);
                    Console.WriteLine($"Добавили символ {param3} в конце строки: {param1}");
                    param1 = StringHandler.RemoveFirstSymbol(param1);
                    Console.WriteLine($"Удалили первый символ: {param1}");
                    param1 = StringHandler.UpSymbol(param1, param2);
                    Console.Write($"Перевод символа {param2} в верхний регистр: ");
                    return param1;
                };

                // Втрой способ через action, но возвращаемого значения нет.
                Action<string, char, char> HandleStringAction = (param1, param2, param3) =>
                {
                    param1 = StringHandler.RemoveDots(param1);
                    Console.WriteLine($"Удалили точки: {param1}");
                    param1 = StringHandler.RemoveSpaces(param1);
                    Console.WriteLine($"Удалили пробелы: {param1}");
                    param1 = StringHandler.AddSymbolToEnd(param1, param3);
                    Console.WriteLine($"Добавили символ {param3} в конце строки: {param1}");
                    param1 = StringHandler.RemoveFirstSymbol(param1);
                    Console.WriteLine($"Удалили первый символ: {param1}");
                    param1 = StringHandler.UpSymbol(param1, param2);
                    Console.WriteLine($"Перевод символа {param2} в верхний регистр: {param1}");
                };

                Console.WriteLine($"{HandleString(baseString, 'f', 'A')}");
                Console.WriteLine("\n");
                HandleStringAction(baseString, 'f', 'A');
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                /**/
            }
            Console.WriteLine("\n");
            Programmer programmer = new Programmer();

            // Создадим в Main некоторое количество объектов (списков).
            List<string> strings = new List<string>() { "abc", "r43","zzz" ,  "t2", "t61" };
            List<string> strings2 = new List<string>() { "ddd", "aaa", "ccc", "zzz" };

            strings.AddRange(strings2);

            // Обработчик события, через лямбда выражение.
            // Если на событие не подписан обработчик, оно не будет срабатывать.
            programmer.Delete += (string message) => Console.WriteLine(message);
            programmer.Mutate += (string message) => Console.WriteLine(message);

            /**
             * Вызов событий
             * Когда событие вызывается, то состояние объектов(списков) меняется
             * в зависимости от вызванного события.
             * 
             * Вызовем многократно события и посмотрим, что произойдет.
             */
            try
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(500);
                    programmer.DeleteFirstEvent(strings);
                    System.Threading.Thread.Sleep(500);
                    programmer.DeleteLastEvent(strings);
                    System.Threading.Thread.Sleep(500);
                    programmer.MutateEvent(strings);
                    System.Threading.Thread.Sleep(1000);
                }
                
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                /**/
            }
            


            Console.ReadKey();
        }
    }
}
