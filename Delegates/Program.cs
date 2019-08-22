using System;

namespace Delegates
{
    class Account
    {
        private int _sum;

        public Account(int sum)
        {
            _sum = sum;
        }

        public void Put(int sum)
        {
            _sum += sum;
        }

        public void Withdraw(int sum)
        {
            if (_sum >= sum)
            {
                _sum -= sum;
            }
        }
    }
    class Program
    {
        delegate void Message();

        delegate int Operation(int x, int y);
        static void Main(string[] args)
        {
            Message message;
            message = Display;

            message.Invoke();
            message();

            Operation operation = Add;
            int result = operation.Invoke(4, 5);
            Console.WriteLine(result);
            operation = Multiplay;
            result = operation(4, 5);
            Console.WriteLine(result);


            Console.ReadKey();
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        static int Multiplay(int x, int y)
        {
            return x * y;
        }
        static void Display()
        {
            Console.WriteLine("Hello");
        }
    }
}
