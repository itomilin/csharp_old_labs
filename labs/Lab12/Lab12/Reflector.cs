using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    // Создадим статически класс рефлектор
    // Заполним его методами по заданию.
    public static class Reflector
    {
        /**
       * a.
       * Выводит все содержмое класса в текстовый файл,
       * первый параметр имя класса, которое нужно анализировать,
       * второй параметр имя файла. Файл сохраняется в текущий проект
       * в Lab12\Lab12\bin\Debug\info.txt
       */
        public static void WriteAllInfoToFile(string className, string fileName)
        {
            Console.WriteLine("==============Пункт a.=================");
            string pathToFile = Path.Combine(Environment.CurrentDirectory, fileName);
            string buffer = className + Environment.NewLine;

            // Базовая переменная, получает всю информацию по названию класса.
            // Не забываем указать пространство имен
            Type tp = Type.GetType(className);
            // Получаем все члены класса, добавим флаги для приватных полей
            var allMembers = tp.GetMembers(System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Static);
            // Читаем в буфер всю информацию
            foreach (var item in allMembers)
            {
                buffer += item + Environment.NewLine;
            }

            // Пишем в файл
            using (StreamWriter writeBuffer = new StreamWriter(pathToFile))
            {
                writeBuffer.Write(buffer);
            }

            Console.WriteLine($"Информация записана в файл {pathToFile}");
        }

        /**
         * b.
         * Извлекаем все публичные методы из заданного класса.
         * В качестве параметра, имя класса.
         */
        public static void FindAllPublicMethods(string className)
        {
            Console.WriteLine("==============Пункт b.=================");
            Console.WriteLine($"Все PUBLIC методы класса {className}:");
            // Базовая переменная, получает всю информацию по названию класса.
            // Не забываем указать пространство имен
            Type tp = Type.GetType(className);

            // Получаем все члены класса, добавим флаги для приватных полей
            var allPublicMethods = tp.GetMethods();
            // Печатаем на консоль
            foreach (var item in allPublicMethods)
            {
                Console.WriteLine(item);
            }
        }

        /**
         * c.
         * Получает свойства и поля класса
         */
        public static void FindAllPropsAndFields(string className)
        {
            Console.WriteLine("==============Пункт c.=================");
            // Базовая переменная, получает всю информацию по названию класса.
            // Не забываем указать пространство имен
            Type tp = Type.GetType(className);

            // Получаем все свойства и поля класса, добавим флаги для приватных полей
            var allProps = tp.GetProperties(System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Static);
            var allFields = tp.GetFields(System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Static);

            Console.WriteLine($"Все свойства класса {className}:");
            // Печатаем на консоль
            foreach (var item in allProps)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Все поля класса {className}:");
            foreach (var item in allFields)
            {
                Console.WriteLine(item);
            }
        }

        /**
         * d.
         * Получаем все реализованные классом интерфейсы.
         */
        public static void FindAllImplementedIfaces(string className)
        {
            Console.WriteLine("==============Пункт d.=================");
            // Базовая переменная, получает всю информацию по названию класса.
            // Не забываем указать пространство имен
            Type tp = Type.GetType(className);

            // Получаем все свойства и поля класса, добавим флаги для приватных полей
            var allInterfaces = tp.GetInterfaces();

            Console.WriteLine($"Все реализованные интерфейсы для класса {className}:");
            // Печатаем на консоль
            foreach (var item in allInterfaces)
            {
                Console.WriteLine(item);
            }
        }

        /**
         * e.
         * Выводим все имена методов, по типу, заданным пользователем
         * тип указываем вторым параметром.
         */
        public static void FindAllMethodNamesByType(string className, Type paramType)
        {
            Console.WriteLine("==============Пункт e.=================");
            // Базовая переменная, получает всю информацию по названию класса.
            // Не забываем указать пространство имен
            Type tp = Type.GetType(className);

            // Получаем все свойства и поля класса, добавим флаги для приватных полей
            var allMethods = tp.GetMethods(System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Static);


            Console.WriteLine($"Выводим все сигнатуры методов с параметром типа {paramType.Name}:");
            // Печатаем на консоль
            foreach (var item in allMethods)
            {
                var parameters = item.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].ParameterType.Name == paramType.Name)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

        /**
         * f.
         * Вызываем метод класса
         * Первый параметр, имя класса из которого хотим вызвать метод
         * Второй параметр, имя метода для класса из первого параметра
         */
        public static void CallMethod(string className, string methodName)
        {
            Console.WriteLine("==============Пункт f.=================");
            // Базовая переменная, получает всю информацию по названию класса.
            // Не забываем указать пространство имен
            Type tp = Type.GetType(className);
            // Получаем все свойства и поля класса, добавим флаги для приватных полей
            var allMethods = tp.GetMethods(System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Static);

            Console.WriteLine($"Вызываем метод {methodName} из класса {className}:");
            // Печатаем на консоль
            foreach (var item in allMethods)
            {
                var parameters = item.GetParameters();
                if (item.Name == methodName)
                {
                    Console.WriteLine(item.Name);

                    var classCtor = tp.GetConstructor(Type.EmptyTypes);
                    object classObject = classCtor.Invoke(new object[] { });
                    item.Invoke(classObject, new object[] { " passed string" });
                }
            }
        }
    }
}
