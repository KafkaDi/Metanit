using System;

namespace Interfaces_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ISchool pupil = new Person();
            IUniversity student = new Person();
            pupil.Study();
            student.Study();

            Person person = new Person();
            ISchool p1 = person as ISchool;
            p1.Study();
                                                        //person  в данном случае является и школьником и студентом
            IUniversity p2 = person as IUniversity;
            p2.Study();

            Console.ReadKey();
        }
    }

    class Person : ISchool, IUniversity
    {
        void ISchool.Study()
        {
            Console.WriteLine("Учёба в школе");
        }

        void IUniversity.Study()
        {
            Console.WriteLine("Учёба в универе");
        }
    }

    interface ISchool
    {
        void Study();
    }

    interface IUniversity
    {
        void Study();
    }
}
