using System;

namespace Преобр_е_типов
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Employee("Tom", "Smith", "ASK"); //восходящее преобразование от производных типов к базовым
            object person2 = new Client("Bob", "Tompson", "SomeBank", 5000); //восходящее преобразование от производных типов к базовым

            // 3й способ
            if (person1 is Client)
            {
                Client client = (Client)person1;
                int result = client.Sum;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Преобразование завершилось неудачно");
            }

            // 2й способ
            //try
            //{
            //    Client client = (Client)person1;
            //    int result = client.Sum;
            //    Console.WriteLine(result);
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Преобразование завершилось неудачно");
            //}


            //  1й способ
            //int sum = ((Client)person2).Sum; //нисходящее преобразование
            //Console.WriteLine(sum);
            //string company = ((Employee)person1).Company;

            //Client client = person1 as Client; //person2 преобразует правильно
            //if (client!=null)
            //{
            //    int result = client.Sum;
            //    Console.WriteLine(result);
            //}
            //else
            //{
            //    Console.WriteLine("Преобразование завершилось неудачно");
            //}

            Console.ReadKey();
        }
    }
    abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person(string name, string surname)
        {
            FirstName = name;
            LastName = surname;
        }
        public abstract void Display();
    }
    class Employee : Person
    {
        public string Company { get; set; }
        public Employee(string name, string surname, string comp) : base(name, surname)
        {
            Company = comp;
        }
        public override void Display()
        {
            Console.WriteLine($"{FirstName} {LastName} работает в компании {Company}");
        }
    }
    class Client : Person
    {
        public int Sum { get; set; }
        public string Bank { get; set; }
        public Client(string name, string surname, string bank, int sum) : base(name, surname)
        {
            Bank = bank;
            Sum = sum;
        }

        public override void Display()
        {
            Console.WriteLine($"{FirstName} {LastName} имеет счёт в банке {Bank} на сумму {Sum}");
        }
    }
}
