using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    // Создадим класс, для 5 пункта
    // объектами будут цвета
    class MyColors
    {
        public string Color { get; set; }
    }

    // Создадим класс, для 5 пункта
    // объектами будут цвета + объект
    class MyObjects
    {
        public string TObject { get; set; }
        public string ObjectColor { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Метод для пункта1
            P1();

            // Пункт 2
            // Создадим несколько объектов векторов
            Lab3.BoolVector instance1 =
                new Lab3.BoolVector(new List<bool> { true, false, true, true, false});

            Lab3.BoolVector instance2 =
                new Lab3.BoolVector(new List<bool> { true, false, true, true, false});

            Lab3.BoolVector instance3 =
                new Lab3.BoolVector(new List<bool> { true, true, true, true, true });

            Lab3.BoolVector instance4 =
                new Lab3.BoolVector(new List<bool> { false, false, false, false, false, false, false });

            // Заполним список объектами
            List<Lab3.BoolVector> boolVectors = new List<Lab3.BoolVector>()
            {
                instance1,
                instance2,
                instance3,
                instance4
            };

            boolVectors.Select(x => x.Vector).ToList().First()
                .ForEach(x =>
                Console.WriteLine(string.Join(" ", x)));

            // Пункт 3
            // Вектора с заданным числом единиц
            int zeroCount = 5;
            Console.WriteLine($"Вектор с числом единиц равным {zeroCount}:");
            boolVectors.Where(x =>
                x.Vector.Count(i => i.Equals(true)) == zeroCount)
                .ToList()
                .ForEach(x =>
                Console.WriteLine(string.Join(" ", x.Vector)));
            Console.WriteLine("==================");
            // Определить и вывести равные векторы в коллекции
            Console.WriteLine("Одинаковые вектора:");
            // Без внешнего цикла сделать не получилось.
            // Берем список и проходим его в цикле
            for (int i = 0; i < boolVectors.Count - 1; i++)
            {
                // с помощью метода linq SequenceEqual, проверяем два списка на одинаковость
                if (boolVectors[i].Vector.SequenceEqual(boolVectors[i + 1].Vector))
                {
                    // выводим на консоль одинаковые
                    boolVectors[i].Vector.ForEach(x => Console.Write($"{x} "));
                    Console.WriteLine();
                }
            }
            Console.WriteLine("==================");
            // Максимальный вектор в коллекции
            Console.WriteLine("Максимальный вектор содержит " +
                $"{boolVectors.Select(x => x.Vector.Count).Max()} элементов:");
            Console.WriteLine("==================");

            // Первый вектор в списке с заданным числом единиц
            int zCount = 3;
            Console.WriteLine($"Первый вектор с числом единиц равным {zCount}");
            boolVectors.Where(x =>
            x.Vector.Count(i => i.Equals(true)) == zCount)
                .Take(1).ToList()
                .ForEach(x => Console.WriteLine(string.Join(" ", x.Vector)));
            Console.WriteLine("==================");

            // Упорядочить вектор по числу единиц
            // Без внешнего цикла также никак не получилось.
            for (int i = 0; i < boolVectors.Count; ++i)
            {
                for (int j = 0; j < boolVectors.Count - 1; ++j)
                {
                    // используем linq count чтобы считать единицы в векторах
                    if (boolVectors[j].Vector.Count(x => x.Equals(true)) <
                boolVectors[j + 1].Vector.Count(x => x.Equals(true)))
                    {
                        // упорядочиваем по количеству единиц
                        List<bool> tmp = boolVectors[j].Vector;
                        boolVectors[j].Vector = boolVectors[j + 1].Vector;
                        boolVectors[j+1].Vector = tmp;
                    }
                }
            }
            Console.WriteLine("Упорядоченные вектора по числу единиц:");
            foreach (var item in boolVectors)
            {
                item.Vector.ForEach(i => Console.Write($"{i} "));
                Console.WriteLine();
            }

            // 4 пункт
            // Собственный запрос
            var l1 = new List<int> { 1, 2, 3, -5, 20, 1 };
            Console.WriteLine("==============");
            var result = l1
                .Select(x => Math.Pow(x, 2)) // проецируем и возводим каждый элемент в квадрат
                .OrderByDescending(x => x) // Упорядочиваем по убыванию
                .GroupBy(x => x).Select(x => x.Key) // Применим группировку, одинаковые элементы сгруппируются
                .Take(3) // с помощью метода разбиения возьмем первые 3 элемента
                .Aggregate((x, y) => x * y); // c помощью метода агрегирования, умножим элементы
            Console.WriteLine(result);


            // 5 пункт
            // groupby применяется для объединения сложных типов

            // Заполним списки, объектами произвольных классов
            List<MyColors> colors = new List<MyColors>()
            { 
                new MyColors{ Color = "red" },
                new MyColors{ Color = "white" },
                new MyColors{ Color = "green" },
                new MyColors{ Color = "light-blue" }
            };
            List<MyObjects> objects = new List<MyObjects>()
            {
                new MyObjects{ TObject = "car", ObjectColor = "red" },
                new MyObjects{ TObject = "house", ObjectColor = "white" },
                new MyObjects{ TObject = "train", ObjectColor = "black" }
            };

            // Находим соответствие между двумя списками
            // Если соответствие найдены, то применяется объединение двух групп объектов
            colors.Join(objects,
                x => x.Color,
                y => y.ObjectColor,
                (x, y) => new { x.Color, y.TObject })
                .ToList()
                .ForEach(i => Console.WriteLine($"{i.TObject} - {i.Color}"));

            Console.ReadKey(); 
        }

        // 1
        private static void P1()
        {
            // Задаем массив типа string
            List<string> months = new List<string>()
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "Jule",
                "August",
                "September",
                "October",
                "November",
                "December"
            };

            // Пишем запрос, который выбирает элементы равные заданному len
            int len = 3;
            Console.WriteLine($"Найденные элементы с длиной строки = {len}:");
            months.Where(x => x.Length == 3).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            // Пишем запрос, который возвращает только летние и зимние месяцы
            Console.WriteLine("Зимние месяцы:");
            months.Where(x => 
            new List<string>() { "December", "January", "February" }
            .Contains(x)).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            Console.WriteLine("Летние месяцы:");
            months.Where(x =>
            new List<string>() { "June", "Jule", "August" }
            .Contains(x)).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            // Запрос вывода месяцев в алфавитном порядке
            Console.WriteLine("Отсортируем по алфавиту:");
            months.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            // Месяцы с u и длиной  >=4 
            Console.WriteLine("Месяцы с \"u\" и длиной  > 4 :");
            months.Where(x => x.Contains('u') && x.Length > 4)
                .ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
        }
    }
}
