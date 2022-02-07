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
    }
}
