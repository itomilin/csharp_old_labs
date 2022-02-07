using System;

namespace Lab5
{
    // Создадим класс исключений для неверного ввода даты.
    // Наследуемся от пользовательского типа exception
    public class DateException : Exception
    {
        // Конструктор по умолчанию.
        public DateException()
        {
        }

        // Перегруженный конструктор, для передачи строки ошибки.
        public DateException(string errorMsg)
            : base(errorMsg)
        {

        }
    }

    // Добавим второе исключение, например для наименования товара.
    // То будем выбрасыать его.
    public class GoodsNameException : Exception
    {
        // Конструктор по умолчанию.
        public GoodsNameException()
        {
        }

        // Для разнообразия сделаем метод с параметрами,
        // который работает внутри класса исключения.
        public void ExceptionHandler(string errorMsg)
        {
            Console.WriteLine(errorMsg + " нажмите любую кнопку для завершения программы.");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }


    // Добавим третий класс собственного исключения.
    // Например для пустого списка объектов классов организаций.
    public class EmptyObjectsException : Exception
    {
        // Конструктор по умолчанию.
        public EmptyObjectsException()
        {
        }

        // Для разнообразия сделаем метод без параметров, который работает внутри класса исключения.
        public void ExceptionHandler()
        {
            Console.WriteLine("!!ОШИБКА!! Список объектов пуст." +
                " нажмите любую кнопку для завершения программы.");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
