using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Account<int> account1 = new Account<int>();
            Account<int> account3 = new Account<int>();
            Account<string> account2 = new Account<string>();
            account1.Id = 45;
            account2.Id = "234";
            int intId = account1.Id; // распоковка unboxing к типу int
            string strId = account2.Id;
            Console.WriteLine($"acc1: {intId} \nacc2: {strId}");

            //Account account1 = new Account();
            //Account account2 = new Account();
            //в данном варианте создаётся проблема безопасности типов т.к. при приведении типов мы можем получить ошибку
            //account1.Id = 45; // упаковка к типу object
            //account2.Id = "234";
            //int intId = (int)account1.Id; // распоковка unboxing к типу int
            //string strId = (string)account2.Id;
            //Console.WriteLine($"acc1: {intId} \nacc2: {strId}");

            Transaction<Account<int>, string> operation = new Transaction<Account<int>, string>()
            {
                FromAccaunt = account1,
                ToAccaunt = account3,
                Code = "345"
            };

            Transaction<int, string> operation2 = new Transaction<int, string>()
            {
                FromAccaunt = 2345,
                ToAccaunt = 55523,
                Code = "345"
            };

            int x = 34;
            int y = 6;
            Swap<int>(ref x, ref y);
            Console.WriteLine($"x={x}   y={y}");

            Console.ReadKey();
        }
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
    }
    //class Account
    //{
    //    public object Id { get; set; }
    //}
    //обобщения помогают решить проблему упаковки распаковки и повысить производ и обеспечить безопасность типа
    class Transaction<U, V>
    {
        public U FromAccaunt { get; set; }
        public U ToAccaunt { get; set; }
        public V Code { get; set; }

    }
    class Account<T> // T - универсальный параметр; в этот параметр мы можем передеать лубой тип 
    {
        public T Id { get; set; }
        public int Sum { get; set; }
    }
}
