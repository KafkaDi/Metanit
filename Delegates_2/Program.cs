using System;
using System.Linq;
using System.Threading;

namespace Delegates_2
{
    #region CountDelegate
    public delegate int CountDelegate(string messege);
    #endregion


    public delegate void ShowMessage(string messege); //заменим его на обощённый делегат Action<string> и не будем использовать

    #region StringHelper
    public class StringHelper
    {
        public int GetCount(string inputString)
        {
            return inputString.Length;
        }
        public int GetCountSymbolA(string inputString)
        {
            return inputString.Count(c => c == 'A');
        }
    }
    #endregion

    public class Student // это класс издатель и он генерирует событие остальные - классы подписчики 
    {
        //public Action<string> Mooving { get; set; } //это было то свойство до того как мы ввели понятие события, сейчас оно изменится
        public event EventHandler<MoovingEventArgs> Mooving; //MoovingEventArgs - класс который описывает передачу необходимых нам параметров
                                                             // любой класс который мы исп внутри EventHandler должен быть унаследован от баз класса EventArgs
        public void Moove(int distance) //для событий. Например мы хотим сделать опционально подписку на сообщения
        {
            for (int i = 1; i <= distance; i++)
            {
                Thread.Sleep(1000);
                //? это упрощение которое подразумевало if(Mooving != null)
                Mooving?.Invoke(this, new MoovingEventArgs(string.Format($"Идёт перемещение... {i} пройденых метров"))); //this указывает на текущий экз класса
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            student.Mooving += Student_Mooving;
            student.Moove(7);

            #region StringHelper

            StringHelper helper = new StringHelper();
            CountDelegate d1 = helper.GetCount;
            CountDelegate d2 = helper.GetCountSymbolA;

            string testString = "LAMPA";

            Console.WriteLine(testString);
            Console.WriteLine($"Общее количество символов: {TestDelegate(d1, testString)}");
            Console.WriteLine($"Количство символов А: {TestDelegate(d2, testString)}");

            #endregion

            Console.ReadKey();
        }

        private static void Student_Mooving(object sender, MoovingEventArgs e) //первый параметр - это класс издатель class Student
                                                                               // второй параметр - переменная типа унаследованного от MoovingEventArgs в кот передаются все параметры
        {
            Console.WriteLine(e.Message);
        }

        /*
         static void Show(string messege)
        {
            Console.WriteLine(messege);
        }
        */

        #region TestDelegate
        static int TestDelegate(CountDelegate method, string testString)
        {
            return method(testString);
        }
        #endregion

    }
}
