using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    // Возьмем готовый класс из Lab4
    // Наследуем в обобщенном классе интерфейс из п.1

    // Наложим ограничение на generic тип, в данном случае типом может быть любой ссылочный
    // where T : class // class - означает любой ссылочный тип
    class MyList<T> : IGenericInterface<T> where T : class
    {
        // Поле, для хранения списка.
        private List<T> _numbers = new List<T>();

        // Создадим свойство, для получения списка из класса.
        public List<T> Numbers
        {
            get { return _numbers; }
        }

        // Конструктор по умолчанию.
        public MyList()
        {

        }

        /**
         * Объявим конструктор для инициализации списка,
         * с которым будем взаимодействовать.
         * Сделаем, например список целых чисел.
         */
        public MyList(List<T> list)
        {
            // Инициализируем поле класса.
            _numbers = list;
        }


        /** 
         * Ниже представлены два оператора сравнения двух списков.
         * Результатом оператора является логический тип, возвращающее
         * true, если условие истенно и false иначе.
         */
        public static bool operator ==(MyList<T> list1, MyList<T> list2)
        {
            return list1._numbers
                .SequenceEqual(list2._numbers);
        }

        public static bool operator !=(MyList<T> list1, MyList<T> list2)
        {
            return !list1._numbers
                .SequenceEqual(list2._numbers);
        }

        /**
         * Перегруженный оператор для объединения двух списков.
         * После выполнения действия, возвращаем новый объект,
         * список которого будет изменен.
         */
        public static MyList<T> operator *(MyList<T> list1, MyList<T> list2)
        {
            MyList<T> resultList = new MyList<T>();
            resultList._numbers.AddRange(list1._numbers);
            resultList._numbers.AddRange(list2._numbers);

            return resultList;
        }

        /**
         * Перегруженный оператор для добавления элемента в начало.
         * После выполнения действия, возвращаем новый объект,
         * список которого будет изменен.
         */
        public static MyList<T> operator +(T item, MyList<T> list)
        {
            MyList<T> resultList = new MyList<T>(list._numbers);
            resultList._numbers.Insert(0, item);

            return resultList;
        }

        /**
         * Перегруженный оператор для удаления первого элемента из списка.
         * После выполнения действия, возвращаем новый объект,
         * список которого будет изменен.
         */
        public static MyList<T> operator --(MyList<T> list)
        {
            MyList<T> resultList = new MyList<T>(list._numbers);
            resultList._numbers.RemoveAt(0);

            return resultList;
        }

        /**
         * Реализуем необходимые методы интерфейса.
         */
        public void Add(T t) // Добавляет в конце списка, новый элемент
        {
            _numbers.Add(t);
        }

        public void Delete(int index) // Удаляет элемент по указанному индексу
        {
            _numbers.RemoveAt(index);
        }

        public T Peek(int index) // Возвращает элемент по указанному индексу
        {
            return _numbers.ElementAt(index);
        }
    }
}
