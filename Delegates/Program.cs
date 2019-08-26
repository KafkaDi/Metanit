using System;
/* Делегаты могут применятся в качестве параметров метода */
namespace Delegates
{
    class Program
    {
        #region opinion_1
        delegate void Message();
        delegate int Operation(int x, int y);
#endregion
        static void Main(string[] args)
        {
            #region opinion_1
            /*
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
            */
            #endregion

            Account account = new Account(100);
            account.RegisterHandler(Display);
            account.RegisterHandler(ColorDisplay);

            account.Put(100);
            account.Withdraw(100);
            account.UnRegisterHandler(ColorDisplay);
            account.Withdraw(150);
            #region opinion_1
            /*
            DoOperation(4,5,Add);
            DoOperation(4,5,Multiplay);
            */
#endregion
            Console.ReadKey();
        }
        #region opinoin_1
        /*
         static void DoOperation(int x, int y, Operation operation)
         {
             int res = operation(x, y);
             Console.WriteLine(res);
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
         } */
        #endregion

        static void Display(string messege)
        {
            Console.WriteLine(messege);
        }

        static void ColorDisplay(string messege)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(messege);
            Console.ResetColor();
        }

    }
}
