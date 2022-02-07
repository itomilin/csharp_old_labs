using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    // Создадим структуру, которая описывает дату.
    struct DateStruct
    {
        public int Year { get; set; }
        public int Day { get; set; }
        public Months Month { get; set; }
        public int Minute { get; set; }
        public int Hour { get; set; }
    }
}
