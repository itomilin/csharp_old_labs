using System;

namespace Lab5
{
    /**
     * Определим конкретную организацию, является потомком абстрактного класса
     * с абстрактными полями, поэтому обязательно переопределение всех членов класса.
     */
    [Serializable] // укажим тег, для сериализации
    public class MoscowEnergyEstablishment : Organization // Для родителя также необходимо указать тег!
    {
        public override string Name { get; set; } = "МосГорЭнерго";

        public override int Id { get; set; } = 3434;

        public override string PhoneNumber { get; set; } = "495-11-10";

        public override string Address { get; set; } = "г.Москва, Улица Победы 33";

        public override string ToString()
        {
            return $"Лицензия: {Licence}\n" +
                $"Наименование: {Name}\n" +
                $"Номер в реестре: {Id}\n" +
                $"Телефон: {PhoneNumber}\n" +
                $"Адрес: {Address}";
        }
    }
}
