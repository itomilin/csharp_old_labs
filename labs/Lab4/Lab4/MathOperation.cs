using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    // Создадим статический класс, объявим в нем методы по заданию.
    static class MathOperation
    {
        /**
         * Метод, возвращающий максимальное значение списка.
         * На вход получаем объект класса.
         * Используем linq для поиска максимального значения.
         */
        public static string FindMaxValue(List list)
        {
            return list.Numbers.Max();
        }

        /**
         * Метод, возвращающий минимальное значение списка.
         * На вход получаем объект класса.
         * Используем linq для поиска минимального значения списка.
         */
        public static string FindMinValue(List list)
        {
            return list.Numbers.Min();
        }

        /**
         * Метод, возвращающий общее количество элементов списка.
         * На вход получаем объект класса.
         * Чтобы найти количество, используем встроенный метод списка.
         */
        public static int CalculateCount(List list)
        {
            return list.Numbers.Count();
        }


        /**
         * Метод РАСШИРЕНИЯ List подсчета слов, начинающиеся с заглавной буквы.
         * На вход, приходит объект класса.
         * Используем фильтрацию linq, для выборки подходящих элементов.
         */
        public static int CalculateFirstUpperChar(this List list)
        {
            return list.Numbers.Where(x => Char.IsUpper(x[0]) == true).Count();
        }


        /**
         * Метод РАСШИРЕНИЯ List проверяющий есть ли повторяющиеся элементы в списке.
         * Если в списке есть повторяющиеся элементы, возвращаем true, иначе
         * false.
         * Используем linq distinct, который возвращает уникальные элементы.
         * Далее считаем количество элементов и проверяем с исходным списком.
         * Если их количество одинаково, значит список не содержит повторов.
         */
        public static bool CheckRepeatItems(this List list)
        {
            return list.Numbers.Distinct().Count() == list.Numbers.Count ?
                false : true;
        }


        /**
         * Метод РАСШИРЕНИЯ для типа string.
         * Считает количество символов верхнего регистра в заданной строке.
         */
        public static int CountUpperChars(this string str)
        {
            return str.Where(x => char.IsUpper(x)).Count();
        }
    }
}
