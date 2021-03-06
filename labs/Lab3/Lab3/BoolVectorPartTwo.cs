using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    // Добавим в этот частичный класс, только конструкторы.
    partial class BoolVector
    {
        /**
         * Закрытый конструктор. Запрещает создавать объекты для класса через ключевое слово new
         * Если private ctor один в классе, то он запрещает создавать объекты
         * класса. Если конструкторов несколько и хотя бы один из них public, то
         * смысл private конструктора пропдает, он никогда не будет вызван.
         * Также применяется для реализации некоторых паттернов програмирования.
         */
        // Зададим ему параметр, чтобы сигнатура отличалась 
        // и была возможность использовать public ctor.
        private BoolVector(string param)
        {
            Console.WriteLine("Call private ctor.");
        }

        // Конструктор с тремя параметрами.
        public BoolVector(string t1, int t2, double t3)
        {
            // При вызове конструктора, будет создан новый экземпляр.
            // Поэтому инкрементируем счетчик.
            ++objectCounter;

            // Присваиваем новому объекту уникальный код, как сказано в задании.
            ID = GetHashCode();
        }

        // Конструктор без параметров по умолчанию.
        public BoolVector()
        { 
            // При вызове конструктора, будет создан новый экземпляр.
            // Поэтому инкрементируем счетчик.
            ++objectCounter;

            // Присваиваем новому объекту уникальный код, как сказано в задании.
            ID = GetHashCode();
        }

        // Конструктор, для инициализации векторов.
        // Также вектора можно задавать через свойства.
        public BoolVector(List<bool> vector)
        {
            // При вызове конструктора, будет создан новый экземпляр.
            // Поэтому инкрементируем счетчик.
            ++objectCounter;

            // Присваиваем новому объекту уникальный код, как сказано в задании.
            ID = GetHashCode();


            _vector = vector;
        }

        /**
         * Статический конструктор.
         * Срабатывает только ОДИН раз, при первом создании объекта или вызове
         * статического члена класса.
         * Мануально вызвать его невозможно.
         */
        static BoolVector()
        {
            Console.WriteLine("Call static ctor.");
        }
    }
}
