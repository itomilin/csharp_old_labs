using System;
using System.Runtime.Serialization;

namespace Lab5Json
{
    /**
     * Определим конкретную организацию, является потомком абстрактного класса
     * с абстрактными полями, поэтому обязательно переопределение всех членов класса.
     */
    [DataContract] // укажим тег, для сериализации
    public class MoscowEnergyEstablishment : Organization // Для родителя также необходимо указать тег!
    {
        [DataMember]
        public override string Name { get; set; } = "МосГорЭнерго";

        [DataMember]
        public override int Id { get; set; } = 3434;

        [DataMember]
        public override string PhoneNumber { get; set; } = "495-11-10";

        [DataMember]
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
