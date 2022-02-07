using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    class MyClass : Interface1, Interface2
    {
        public int MyProperty { get; set; }

        private int _privateField = 0;

        private int TestPrivateMethod(string str)
        {
            Console.WriteLine("!!call private method!!" + str);
            return 0;
        }

        public static void TestPublicMethod(int intp)
        {

        }

        public void Test(string str)
        {
            throw new NotImplementedException();
        }

        public int TestInt()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Класс myclass и два интерфейса для него, созданы также для тестов

            // Возьмем несколько классов, с предыдущих заданий.
            // Сделаем разбор их классов, передав пространство имен и имя класса
            string CLASS_NAME = typeof(Lab5.Date).FullName;
            //string CLASS_NAME = typeof(Lab9.Programmer).FullName; // Указать имя класса, с пространством имем
            const string FILE_NAME = "info.txt"; // файл для пункта f, из него читаем имя класса и имя метода
            try
            {
                // a.
                Reflector.WriteAllInfoToFile(CLASS_NAME, FILE_NAME);
                // b.
                Reflector.FindAllPublicMethods(CLASS_NAME);
                // c.
                Reflector.FindAllPropsAndFields(CLASS_NAME);
                // d.
                Reflector.FindAllImplementedIfaces(CLASS_NAME);
                //e.
                Reflector.FindAllMethodNamesByType(CLASS_NAME, typeof(int)); // String Object

                // f.
                // Прочтем значения для передаваемых параметров из файла
                // Первый параметр название класса, второй параметр название метода класса
                string pathToFile = Path.Combine(Environment.CurrentDirectory, "fLab12.txt");
                var paramsFromFile = File.ReadAllText(pathToFile).Split(';');
                Reflector.CallMethod(paramsFromFile[0], paramsFromFile[1]);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex);
            }
            catch(Exception ex)
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
