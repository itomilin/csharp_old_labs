using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Student
    {
        public string Name { get; set; } = "Test";
        public int Id { get; set; } = 231;
    }

    class Program
    {
        static void Main(string[] args)
        {
            P1();
            P2();
            P3();
            P4();
            // Проверим работу observablecollection
            // будем удалять элементы
            for (int i = 0; i < 3; i++)
            {
                System.Threading.Thread.Sleep(300);
                dates.RemoveAt(i);
            }

            // будем добавлять элементы
            for (int i = 0; i < 3; i++)
            {
                System.Threading.Thread.Sleep(300);
                dates.Add(new Lab5.Date(12 + i, 12 + i, 12, 2020 + i, "December"));
            }
            
            Console.ReadKey();
        }

        // Задание из пункта 1
        private static void P1()
        {
            // a. Создадим 5 случайных чисел.
            Random r = new Random();
            List<int> vs = new List<int>();
            for (int i = 0; i < 5; ++i)
            {
                vs.Add(r.Next(4, 50));
                System.Threading.Thread.Sleep(50);
            }

            // Создадим необобщенную коллекцию arraylist
            // Поскольку тип элементов object, то мы можем добавить в нее любой тип.
            ArrayList arrayList = new ArrayList();
            // a. Заполним случайными целыми 5 числами
            arrayList.AddRange(vs);
            // b. Добавим строку
            arrayList.Add("testString");
            // c. Добавим объект типа Student
            arrayList.Add(new Student());
            // d. Удалим заданный элемент.
            Console.Write("Введите элемент, который хотите удалить: ");
            int index = Convert.ToInt32(Console.ReadLine());
            arrayList.RemoveAt(index);
            // e. Выведем на консоль все элементы.
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // f. Выполним поиск заданной строки в списке.
            string findString = "testString";
            for (int i = 0; i < arrayList.Count; i++)
            {
                if (arrayList[i].Equals(findString))
                {
                    Console.WriteLine($"Строка {findString} найдена, индекс = {i}");
                    break;
                }
            }
        }
        
        // Второй пункт, вариант 10, словарь.
        private static void P2()
        {
            // СОздадим словарь и заполним его.
            Dictionary<int, int> dict = new System.Collections.Generic.Dictionary<int, int>()
            {
                { 0, 123 },
                { 1, 223 },
                { 2, 223 },
                { 3, 223 },
                { 4, 423 },
                { 5, 523 }
            };
            // a. вывод на консоль
            foreach (var item in dict)
            {
                Console.WriteLine($"Key: {item.Key}\tValue: {item.Value}");
            }
            Console.WriteLine("\n");

            // b. Удалить последовательные элементы
            dict = dict.GroupBy(pair => pair.Value)
                         .Select(group => group.First())
                         .ToDictionary(pair => pair.Key, pair => pair.Value);

            // c. Добавим другие элементы
            dict.Add(123, 1233);
            dict.Add(888, 12333);

            // d. Создадим вторую коллекцию hashset и заполним
            HashSet<int> hashSet = new HashSet<int>();
            //при нехватке - генерируйте ключи, в случае избыточности – оставляйте TValue.
            foreach (var item in dict)
            {
                hashSet.Add(item.Value);
            }

            // e. Выводим на консоль
            Console.WriteLine("**HashSet**");
            foreach (var item in hashSet)
            {
                Console.WriteLine($"Значение: {item}");
            }

            // f. Выполним поиск заданной строки в списке.
            int findValue = 1233;
            if (hashSet.Contains(findValue))
            {
                Console.WriteLine($"Значение {findValue} найдено!");
            }
            else
            {
                Console.WriteLine($"Значение {findValue} НЕ найдено!");
            }
        }

        // Третий
        private static void P3()
        {
            // СОздадим словарь и заполним его.
            Dictionary<int, Lab5.Date> dict = 
                new System.Collections.Generic.Dictionary<int, Lab5.Date>()
            {
                { 0, new Lab5.Date(12, 12, 12, 2020, "December") },
                { 1, new Lab5.Date(11, 11, 12, 2020, "November") },
                { 2, new Lab5.Date(15, 14, 12, 2020, "September") },
                { 3, new Lab5.Date(10, 13, 12, 2021, "September") },
                { 4, new Lab5.Date(11, 12, 12, 2022, "May") },
                { 5, new Lab5.Date(23, 42, 12, 2020, "June") }
            };
            // a. вывод на консоль
            foreach (var item in dict)
            {
                Console.WriteLine($"Key: {item.Key}\tValue: {item.Value}");
            }
            Console.WriteLine("\n");

            // b. Удалить последовательные элементы// Удалим последовательные года
            dict = dict.GroupBy(pair => pair.Value.Year)
                         .Select(group => group.First())
                         .ToDictionary(pair => pair.Key, pair => pair.Value);

            //foreach (var item in uniqueValues)
            //{
            //    Console.WriteLine(item);
            //}

            // c. Добавим другие элементы
            dict.Add(123, new Lab5.Date(12, 12, 12, 2025, "July"));
            dict.Add(888, new Lab5.Date(12, 12, 12, 2026, "September"));
            dict.Add(889, new Lab5.Date(12, 12, 12, 2026, "September"));

            // d. Создадим вторую коллекцию hashset и заполним
            HashSet<Lab5.Date> hashSet = new HashSet<Lab5.Date>();
            //при нехватке - генерируйте ключи, в случае избыточности – оставляйте TValue.
            foreach (var item in dict)
            {
                hashSet.Add(item.Value);
            }

            // e. Выводим на консоль
            Console.WriteLine("**HashSet**");
            foreach (var item in hashSet)
            {
                Console.WriteLine($"Значение: {item}");
            }

            // f. Выполним поиск заданной строки в списке.
            int findYear = 2026;
            Console.WriteLine($"Найденные элементы с годом равным {findYear}:");
            hashSet.Where(x => x.Year.Equals(findYear)).ToList().ForEach(i => Console.WriteLine(i));     
        }


        // Четвертый пункт

        // Создадим observablecollection и заполним ее.
        private static ObservableCollection<Lab5.Date> dates = new ObservableCollection<Lab5.Date>()
        {
            new Lab5.Date(12, 12, 12, 2020, "December"),
            new Lab5.Date(11, 11, 12, 2020, "November"),
            new Lab5.Date(15, 14, 12, 2020, "September"),
            new Lab5.Date(10, 13, 12, 2021, "September"),
            new Lab5.Date(11, 12, 12, 2022, "May"),
            new Lab5.Date(23, 42, 12, 2020, "June")
        };

        private static void P4()
        {
            // Подпишем обработчик события, на событие colelctionchanged оформим в виде lambda
            dates.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) =>
            {
                // Проверяем через свойство action, какое действие произошло с коллекцией
                // и выводим сообщение в зависимости от действия
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Console.WriteLine($"Добавлен новый элемент - {e.NewItems[0]}");
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Console.WriteLine($"Удален элемент - {e.OldItems[0]}");
                        break;
                    default:
                        break;
                }
            };
        }
    }
}
