using System;

namespace Ограничения_обобщений
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc1 = new Account(23) { Sum = 4500 };
            Account acc2 = new Account(44) { Sum = 5000 };
            DemandAccount acc3 = new DemandAccount(102) { Sum = 4000 };
            DemandAccount acc4 = new DemandAccount(125) { Sum = 3000 };
            /*
            Transaction<Account, int> t1 = new Transaction<Account, int> //int указан как пример
            {
                FromAccaunt = acc1,
                ToAccaunt = acc2,
                Sum = 700
            };

            Transaction<DemandAccount, int> t2 = new Transaction<DemandAccount, int>
            {
                FromAccaunt = acc3,
                ToAccaunt = acc4,
                Sum = 700
            };

            t1.Execute();
            t2.Execute();
            */
            //работаем с методом Transact
            Transakt<Account>(acc1, acc2, 123);
            
            Console.ReadKey();

        }
        // создадим ограничение обощений в методе
        public static void Transakt<T>(T acc1, T acc2, int sum) where T : Account
        {
            if (acc1.Sum > sum)
            {
                acc1.Sum -= sum;
                acc2.Sum += sum;
                Console.WriteLine($"{acc1.Id} : {acc1.Sum} \n{acc2.Id} : {acc2.Sum}");
            }
        }
    }
    class Transaction<T, K> 
        where T : Account 
        where K : struct /* так же в качестве ограничения можно использовать структуры struct,
                                              классы class, конструктор по умолчанию new(), для нескольких обощений 
                                              необходимо указать огранияение каждого*/
    {
        public T FromAccaunt { get; set; } // с какого счёта
        public T ToAccaunt { get; set; } // на какой счёт
        public int Sum { get; set; } // сымма перевлда
        public void Execute() //выполняем перевод
        {
            if (FromAccaunt.Sum > Sum)
            {
                FromAccaunt.Sum -= Sum;
                ToAccaunt.Sum += Sum;
                Console.WriteLine($"{FromAccaunt.Id} : {FromAccaunt.Sum} \n{ToAccaunt.Id} : {ToAccaunt.Sum}");
            }
        }

    }
    class Account
    {
        public int Id { get; }
        public int Sum { get; set; } //сумма на счёте
        public Account(int id)
        {
            Id = id;
        }
    }
    class DemandAccount : Account
    {
        public DemandAccount(int id) : base(id)
        {
        }
    }
}
