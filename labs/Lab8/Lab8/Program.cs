using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        public delegate void MyDelegate();
        static void Main(string[] args)
        {
            MyDelegate testDelegate1 =TestMethod;
            MyDelegate testDelegate2 = TestMethod;
            MyDelegate testDelegate3 = TestMethod;

            try
            {
                // На класс-обобщение наложено ограничение, в качестве типа
                // могут быть только ссылочные типы данных string, классы, делегаты итд
                /*MyList<int> instance22 = new MyList<int>(new List<int>
                { 1, 2, 3, 4, 5 });
                MyList<double> instance33 = new MyList<double>(new List<double>
                { 1.4, 2.5, 3.5, 4.1, 5.67 });
                */ //ошибка компиляции т.к int, double являются структурным типом, а не ссылочным

                // Проверим работу обобщение на ссылочных типах.
                MyList<string> instance = new MyList<string>(new List<string>
                { "on", "off", "ABC", "test", "test2" });
                MyList<MyDelegate> instance2 = new MyList<MyDelegate>(new List<MyDelegate>
                { testDelegate1, testDelegate2, testDelegate3 });

                // СОздадим несколько объектов пользовательского класса из Lab5
                Date date = new Date();
                Date date2 = new Date();
                Date date3 = new Date();

                // Заполним обобщенный класс
                // Поскольку класс является ссылочным типом, ошибок также не возникает
                MyList<Date> instance3 = new MyList<Date>(new List<Date>
                { date, date2, date3 });

                // Проверим методы, которые создали в обобщенном интерфейсe
                // и реализовали в обобщенном классе.
                instance.Add("MethodIFace");
                instance.Delete(0);
                Console.WriteLine(instance.Peek(instance.Numbers.Count - 1));
                Console.WriteLine("=====================");
                // Выведем на консоль вектора разных типов
                instance.Numbers.ForEach((string i) => { Console.WriteLine(i); });
                instance2.Numbers.ForEach((MyDelegate i) => { Console.WriteLine(i); });
                instance3.Numbers.ForEach((Date i) => { Console.WriteLine(i); });
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                /*
                 */
            }

            Console.ReadKey();
        }

        public static void TestMethod()
        {

        }
    }
}
