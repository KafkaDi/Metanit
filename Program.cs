using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            User tom = new User(); //пользуемся к-ром по умолч
            tom.name = "Tom";
            tom.age = 22;
            tom.Info();

            User bob = new User("Bob"); //пользуемся 1м к-ром
            bob.name = "Bob";
            bob.age = 33;
            bob.Info();

            User kot = new User("Pupuska", 1); //польз-ся 2м к-ром
            kot.Info();

            User pok = new User { age = 146, name = "procent" }; //передаём переметры во 2й конструктор через инициализатор (напрямую) 
            pok.Info();

            Console.ReadKey();
        }
    }
}
