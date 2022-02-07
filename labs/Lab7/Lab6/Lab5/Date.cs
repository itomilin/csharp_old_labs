using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    /**
     * Герметизированный класс дата.
     * Модификатор sealed означает, что его нельзя наследовать.
     * Реализуем члены интерфейса IDate.
     */
    sealed class Date : IDate
    {
        // Дадим реализацию членам интерфейса
        public int Hour { get; set; } = 0;
        public int Minute { get; set; } = 0;
        public int Day { get; set; } = 0;
        public int Year { get; set; } = 0;
        public string Month { get; set; } = "";
        ////////////////////////////////////////////

        // Конструктор, инициализация полей осуществляется через него, можно также
        // напрямую через свойства.
        public Date(int hour,
            int minute,
            int day,
            int year,
            string month)
        {
            Hour = hour;
            Minute = minute;
            Day = day;
            Year = year;
            Month = month;
        }

        // Добавим перегрузку конструктора, чтобы он мог работать и со структурой.
        public Date(DateStruct date)
        {
            // Воспользуемся собственным исключением, будем выбрасывать его, если условие верное.
            // Будем проверять не орицательна ли дата.
            // Месяц в данном случае можно не проверять, т.к он жестко задан, с помощью Enum
            if (date.Year < 0 ||
                date.Day <= 0 || date.Day > 31)
            {
                // Будем выбрасывать пользовательское исключение.
                // Поскольку конструктор перегружен, то можно указать причину исключения.
                throw new DateException("!!ОШИБКА!!Год или день задан неверно.");
            }

            // Также проверим время.
            if (date.Hour < 0 || date.Hour >= 24)
            {
                throw new DateException("!!ОШИБКА!Неверно указан час.");
            }
            if (date.Minute < 0 || date.Minute >= 60)
            {
                throw new DateException("!!ОШИБКА!Неверно указаны минуты.");
            }

            Hour = date.Hour;
            Minute = date.Minute;
            Day = date.Day;
            Year = date.Year;
            Month = date.Month.ToString();
        }

        /// <summary>
        /// Блок переопределения базовых методов для класса object,
        /// согласно заданию. Переопределим на свое усмотрение.
        /// </summary>
        
        /**
         * Для equals будем сравнивать года объектов.
         * Если они равны, то выводим true, иначе false.
         */
        public override bool Equals(object obj)
        {
            return (int)obj == Year;
        }

        /**
         * Для gethashcode будем возвращать хеш поля года.
         */
        public override int GetHashCode()
        {
            return Year.GetHashCode();  
        }

        /**
         * Для tostring выводом будет текущие значения, которые
         * определенные в объекте и тип объекта.
         */
        public override string ToString()
        {
            return $"{GetType()} " +
                $"{Day}-{Month}-{Year} {Hour}:{Minute}"; 
        }

        // Реализация метода из интерфейса.
        public void PrintDate()
        {
            Console.WriteLine($"{Day}-{Month}-{Year} {Hour}:{Minute}");
        }
    }
}
