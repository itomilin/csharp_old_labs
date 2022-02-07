using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /**
     * Определяем класс по варианту.
     * Сделаем его partial, например, чтобы разбить на несколько файлов.
     * При компиляции, классы отмеченные partial будут собраны в один.
     */
    partial class BoolVector
    {
        /// <summary>
        /// Создадим блок private полей, как сказано в задании.
        /// </summary>
        // Поле только для чтения, содержащее уникальный хеш.
        private readonly int ID;

        // Константное поле класса.
        private const string CLASS_NAME = "BoolVector";

        // Статическое поле хранящее количество созданных объектов.
        private static int objectCounter = 0;

        // Поле, хранит заданный вектор логических элементов.
        private List<bool> _vector;

        /// <summary>
        /// Создадим блок свойств, для работы с полями класса.
        /// </summary> 
        // Свойство, выводящее уникальный хеш объекта.
        // Поскольку поле readonly, от модификатора set нет смысла.
        public int Id
        {
            get { return ID; }
        }

        // Свойство, выводящее константное поле.
        // Заменить, поскольку поле константно, от модификатора set нет смысла.
        public string Name
        {
            get { return CLASS_NAME; }
        }

        // Свойство, для получения значения количества созданных объектов класса.
        public int Counter
        {
            get { return objectCounter; }
        }

        // Свойство для получения вектора и для присваивания полю вектора.
        public List<bool> Vector
        {
            get { return _vector; }
            set { _vector = value; }
        }

        /// <summary>
        /// Блок переопределения стандартных object методов.
        /// ToString, Equals, GetHashCode
        /// Придумаем им какие-то тестовые реализации.
        /// </summary>
        public override string ToString()
        {
            return $"**Call override ToString()**" +
                $"\nHash: {ID}\nClassName: {CLASS_NAME}\n";
        }

        public override int GetHashCode()
        {
            return objectCounter.GetHashCode() ^
                CLASS_NAME.GetHashCode() ^
                ID.GetHashCode() + 50;
        }

        public override bool Equals(object obj)
        {
            List<bool> vector;
            try
            {
                // Вектор, который хотим сравнить. Делаем преобразование к заданному типу.
                vector = (List<bool>)obj;
            }
            catch (Exception)
            {
                throw new Exception("Невозможно преобразовать тип.");
            }

            // Выполняем сравнение и возвращаем результат.
            return _vector.SequenceEqual(vector);
        }

        /// <summary>
        /// Создадим методов, для указанных действий.
        /// </summary> 
        /**
         * Конъюнкция
         * true  & true  = true
         * true  & false = false
         * false & false = false
         * false & true  = false
         */
        public void Conjunction(bool logic)
        {
            var v = _vector.Select(x => x & logic).ToList();
            foreach (var item in v)
            {
                Console.Write($"{item} ");
            }
        }

        /**
         * Дизъюнкция
         * false | false = false
         * true  | true  = true
         * true  | false = true
         * false | true  = true
         */
        public void Disjunction(bool logic)
        {
            var v = _vector.Select(x => x | logic).ToList();
            foreach (var item in v)
            {
                Console.Write($"{item} ");
            }
        }

        /**
         * Отрицание
         * !false = true
         * !true  = false
         */
        public void Negative()
        {
            var v = _vector.Select(x => !x).ToList();
            foreach (var item in v)
            {
                Console.Write($"{item} ");
            }
        }

        // Подсчет единиц.
        public int CalculateZero()
        {
            return _vector.Where(x => x == true).Count();
        }

        // Подсчет нулей, результат будем возвращать с помощью out.
        public void CalculateNull(out int result)
        {
            result = _vector.Where(x => x == false).Count();
        }

        // Статический метод для вывода информации о классе.
        public static void ClassInfo(ref int t)
        {
            t = 23232;
            Console.WriteLine("**Вызван статический метод информации о классе**\n" +
                "класс Булев вектор (BoolVector).\n" +
                "Реализовать методы для выполнения поразрядных  конъюнкции,\n" +
                "дизъюнкции  и отрицания  векторов, а также подсчета числа\n" +
                "единиц и нулей в векторе.");
        }
    }
}
