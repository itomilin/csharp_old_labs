using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    // Создаем обобщенный интерфейс с методами
    // добавить, удалить, просмотреть.
    public interface IGenericInterface<T>
    {
        void Add(T t);

        void Delete(int index);

        T Peek(int index);
    }
}
