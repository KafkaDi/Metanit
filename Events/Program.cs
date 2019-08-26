using System;

namespace Events
/*
 * События сигнализируют системе что произошло какое то действие
 */
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(100);
            account.Added+=new AccountStateHendler(Display);
            account.Withdrawn += Display;
            account.Withdrawn += ColorDisplay;
            //account.RegisterHandler(Display);
            //account.RegisterHandler(ColorDisplay);

            account.Put(100);
            account.Withdraw(100);
            account.Withdrawn -= ColorDisplay;
            //account.UnRegisterHandler(ColorDisplay);
            account.Withdraw(150);
            Console.ReadKey();
        }
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
