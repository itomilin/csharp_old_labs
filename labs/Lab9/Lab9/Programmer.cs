using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    // Определим класс, по заданию.
    class Programmer
    {
        // Определим делегат.
        public delegate void Notify(string message);

        // Определим два события, которые указаны в задании.
        // Типом события, является делегат, который создали выше.
        public event Notify Delete = null;

        public event Notify Mutate = null;

        // Методы, для которых вызывается событие.
        // Удаляем первый элемент из списка.
        public void DeleteFirstEvent(List<string> list)
        {
            if (Delete != null)
            {
                list.RemoveAt(0);
                // При вызове события передаем в него строку о том, что оно произошло.
                Delete.Invoke("Удален первый элемент: " 
                    + string.Join(" ", list));
            }
        }

        // Удаляем последний элемент из списка.
        public void DeleteLastEvent(List<string> list)
        {
            if (Delete != null)
            {
                list.RemoveAt(list.Count - 1);
                Delete.Invoke("Удален последний элемент: "
                    + string.Join(" ", list));
            }
        }

        // Сортируем список, тем самым "мутируя" список.
        public void MutateEvent(List<string> list)
        {
            if (Mutate != null)
            {
                list.Sort();
                Mutate.Invoke("Отсортированный список: "
                    + string.Join(" ", list));
            }
        }
    }
}
