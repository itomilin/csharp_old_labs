using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    // Создаем класс согласно варианту.
    class List
    {
        /** 
         * Добавим вложенный тип, который содержит Id, имя и организацию создателя
         * также инициализируем их. Будем использовать автоматические свойства.
         * Используем возможность их первичной инициализации.
         */
        public class NestedInfo
        {
            public int Id { get; } = 5;
            public string Name { get; } = "TestName";
            public string Organization { get; } = "TestOrganization";
        }

        /**
         * Определим еще один вложенный класс.
         * Свойство будет возвращать форматированную дату и время.
         */
        public class NestedDate
        {
            public string Date { get; } 
                = DateTime.Now.ToString("yyyy-MM-ddT_HH:mm:ss");
        }

        // Поле, для хранения списка.
        private List<string> _numbers = new List<string>();

        // Создадим свойство, для получения списка из класса.
        public List<string> Numbers
        {
            get { return _numbers; }
        }

        // Конструктор по умолчанию.
        public List()
        {

        }

        /**
         * Объявим конструктор для инициализации списка,
         * с которым будем взаимодействовать.
         * Сделаем, например список целых чисел.
         */
        public List(List<string> list)
        {
            // Инициализируем поле класса.
            _numbers = list;
        }


        /** 
         * Ниже представлены два оператора сравнения двух списков.
         * Результатом оператора является логический тип, возвращающее
         * true, если условие истенно и false иначе.
         */
        public static bool operator ==(List list1, List list2)
        {
            return list1._numbers
                .SequenceEqual(list2._numbers);
        }

        public static bool operator !=(List list1, List list2)
        {
            return !list1._numbers
                .SequenceEqual(list2._numbers);
        }

        /**
         * Перегруженный оператор для объединения двух списков.
         * После выполнения действия, возвращаем новый объект,
         * список которого будет изменен.
         */
        public static List operator *(List list1, List list2)
        {
            List resultList = new List();
            resultList._numbers.AddRange(list1._numbers);
            resultList._numbers.AddRange(list2._numbers);

            return resultList;
        }

        /**
         * Перегруженный оператор для добавления элемента в начало.
         * После выполнения действия, возвращаем новый объект,
         * список которого будет изменен.
         */
        public static List operator +(string item, List list)
        {
            List resultList = new List(list._numbers);
            resultList._numbers.Insert(0, item);

            return resultList;
        }

        /**
         * Перегруженный оператор для удаления первого элемента из списка.
         * После выполнения действия, возвращаем новый объект,
         * список которого будет изменен.
         */
        public static List operator --(List list)
        {
            List resultList = new List(list._numbers);
            resultList._numbers.RemoveAt(0);

            return resultList;
        }
    }
}
