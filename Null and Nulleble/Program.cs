using System;

namespace Null_and_Nulleble
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = null; // знчение null можно присваивать переменным ссылочного типа, так же все классы предст собой ссылочные типы
            Country country = null;
            string name = "";

            int? age = null;
            int y = age.GetValueOrDefault();
            Console.WriteLine(y); // 0 будет значением по умолчанию

            int? hight = 5;
            int x = hight.Value; // конструкция для пролучения значения типа Nulleble, но может возникнуть ошибка если значение было null поэт исп GetValueOrDefault
            int z = hight.GetValueOrDefault();
            Console.WriteLine(z);

            int? width = null;
            int k = width ?? 10; // оператор ?? возвратит значение стоящее после ?? если значение до ?? будет null
            Console.WriteLine(k);

            //то же самое только развёрнуто
            System.Nullable<int> age2 = null;
            double? d = null;

            State? stateNulleble = new State { Name = "Narnia" }; // = null;
            if (stateNulleble.HasValue == true)
            {
                State state = stateNulleble.Value;
                Console.WriteLine(state.Name);
            }
            else
            {
                Console.WriteLine("stateNulleble is equal to null");
            }
            //State state = stateNulleble.Value;
            //Console.WriteLine(state.Name);

            Console.ReadKey();
        }
    }
    class Country
    {
        public string Name { get; set; }
    }
    struct State
    {
        public string Name { get; set; }
    }
}
