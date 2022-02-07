using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Протестируем работу вложенных классы.
            // Выведем свойства из вложенных классов.
            List.NestedInfo info = new List.NestedInfo();
            Console.WriteLine($"ID = {info.Id}; NAME = {info.Name}; " +
                $"ORGANIZATION = {info.Organization}");
            List.NestedDate date = new List.NestedDate();
            Console.WriteLine(date.Date);

            // Создадим объекты.
            List instance = new List(new List<string> 
            { "on", "off", "ABC", "test", "test2" });

            List instance2 = new List(new List<string>
            { "zn2", "off", "ABC", "Qest", "Qwerty" });

            // Проверим работу методов расширений.
            string word = "dfDsf";
            Console.WriteLine($"Количество символов верхнего регистра в " +
                $"слове {word} = {word.CountUpperChars()}");
            Console.WriteLine("Список:");
            instance.Numbers.ForEach(i => { Console.WriteLine(i); });
            Console.WriteLine($"В списке есть повторения? " +
                $"{instance.CheckRepeatItems()}\nКоличество элементов, которое " +
                $"начинается с верхнего регистра = {instance.CalculateFirstUpperChar()}");
            /////////////////////////////////////

            Console.WriteLine("\n\n");

            Console.WriteLine("Список1:");
            instance.Numbers.ForEach(i => { Console.WriteLine(i); });
            Console.WriteLine("Список2:");
            instance2.Numbers.ForEach(i => { Console.WriteLine(i); });
            // Проверим перегрузку операторов.
            Console.WriteLine($"Списки НЕ равны? {instance != instance2}");
            Console.WriteLine($"Списки равны? {instance == instance2}");

            Console.WriteLine("Объединим два списка в один:");
            (instance * instance2).Numbers
                .ForEach(i => { Console.WriteLine(i); });
            Console.WriteLine("------------");

            Console.WriteLine("Добавим в начало списка1 слово:");
            ("FIRSTWORD" + instance).Numbers
                .ForEach(i => { Console.WriteLine(i); });
            Console.WriteLine("------------");
            Console.WriteLine("Удалим из списка1 ранее добавленный элемент:");
            (--instance).Numbers
                .ForEach(i => { Console.WriteLine(i); });
            Console.WriteLine("------------");
            ///////////////////////////////////

            Console.WriteLine($"Максимальный элемент в списке1: " +
                $"{MathOperation.FindMaxValue(instance)}\n" +
                $"Минимальный элемент: {MathOperation.FindMinValue(instance)}\n" +
                $"Количество элементов: {MathOperation.CalculateCount(instance)}\n");

            Console.ReadKey();
        }
    }
}
