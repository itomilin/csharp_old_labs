using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = 0;
            /**
             * Протестируем созданный класс, вызовами методов, свойств итд...
             */
            /**
             * По заданию требовалось передать что-то по ссылке, для одного из методов класса.
             * При передаче по ссылке, не создается копия объекта,
             * поэтому значение измененное в методе, изменится и в месте вызова.
             */
            BoolVector.ClassInfo(ref t); // Информация о классе.
            BoolVector instance1 = new BoolVector();

            BoolVector instance2 = new BoolVector(new List<bool> { true, false, true, false, true });

            Console.WriteLine("Базовый вектор, без изменений:");
            for (int i = 0; i < instance2.Vector.Count; i++)
                Console.Write($"{instance2.Vector[i]} ");

            Console.WriteLine("\nРезультат после конъюнкции по значению false:");
            instance2.Conjunction(false);

            Console.WriteLine("\nРезультат после дизъюнкции по значению true:");
            instance2.Disjunction(true);

            Console.WriteLine("\nРезультат после отрицания:");
            instance2.Negative();

            int result = 0;
            instance2.CalculateNull(out result);
            Console.WriteLine($"\nКоличество нулей в векторе: {result}\n" +
                $"Количество единиц в векторе: {instance2.CalculateZero()}");

            Console.WriteLine($"Количество созданных объектов класса: {instance2.Counter}");
            Console.WriteLine("\n\n");

            // Создадим список объектов.
            List<BoolVector> boolVectors = new List<BoolVector>()
            {
                new BoolVector(new List<bool> { true, false, false, false, false }),
                new BoolVector(new List<bool> { true, false, false, false, false }),
                new BoolVector(new List<bool> { true, false }),
                new BoolVector(new List<bool> { true, false }),
                new BoolVector(new List<bool> { false, false }),
                new BoolVector(new List<bool> { true, false, true }),
                new BoolVector(new List<bool> { true, false })
            };

            // a) Выводим на консоль вектора
            foreach (var item in boolVectors)
            {
                Console.Write($"Хеш вектора: {item.Id}, содержимое вектора: ");
                for (int i = 0; i < item.Vector.Count; i++)
                {
                    Console.Write($"{item.Vector[i]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            // a) Зададим числа и попробуем найти соответствия
            int desireNullNumber = 4;
            int desireZeroNumber = 2;
            foreach (var item in boolVectors)
            {
                // Возвращать значение будем с помощью out, по требованию в задании.
                item.CalculateNull(out int res2);
                if (res2 == desireNullNumber)
                {
                    Console.WriteLine("Вектор с заданным числом нулей найден" +
                        $" его хеш {item.Id}");
                }
                if (item.CalculateZero() == desireZeroNumber)
                {
                    Console.WriteLine("Вектор с заданным числом единиц найден" +
                        $" его хеш {item.Id}");
                }
            }

            // b) Ищем равные вектора перебором и выводим их.
            for (int i = 0; i < boolVectors.Count; ++i)
            {
                for (int j = 1; j < boolVectors.Count - 1; ++j)
                {
                    if (i != j) // Пропускаем текущий, чтобы исключить случай, когда вектор равен сам себе.
                    {
                        // Вызываем переопределенный equals
                        if (boolVectors[i].Equals(boolVectors[j].Vector))
                        {
                            Console.WriteLine($"Вектор {boolVectors[i].Id} равен вектору {boolVectors[j].Id}");
                        }
                    }
                }
            }

            // Анонимный тип. Нужны для получения каких-нибудь данных,
            // и преобразовывания во что-то для дальнейшей обработки.
            // Создадим тестовый анонимный тип.
            var test = new { Id = 12334, Name = "test", Counter = 34 };
            // Теперь вызовем свойства анонимного типа.
            Console.WriteLine($"\nВызов анонимного типа {test.Id}," +
                $"{test.Name}, {test.Counter}");

            Console.ReadKey();
        }
    }
}
