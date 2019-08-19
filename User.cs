using System;

namespace ConsoleApp1
{
    class User
    {
        public string name; // поля класса
        public int age;

        public User(string name)  //пользовательский к-тор в () параметр конструктора а зис. - это поле класса
        {
            this.name = name;
        }
        public User()  //пустой конструктор, так же создаётся по умолчанию когда нет других к-ров
        {

        }
        public User(string n, int age) : this(n)  //пользовательский к-тор в нём 1й парам. заимствуется у верхнего к-ра (n)
        {
            this.age = age;
        }
        public void Info() //поведение класса
        {
            Console.WriteLine($"{name} - {age}");
        }
    }
}
