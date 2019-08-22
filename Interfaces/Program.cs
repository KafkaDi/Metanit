using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IAccount client = new Client("Tom", 3000);
            client.Put(500);
            Console.WriteLine(client.CurrentSum);
            client.Withdraw(600);
            Console.WriteLine(client.CurrentSum);

            Client client2 = (Client)client; // = client as Client 
            string name = ((Client) client).Name; //получения значения свойства Name в переменную, исп приведение типов т.к. client является 
            string name1 = client2.Name;          //производной интерфейса IAccount а свойство Name содержится в инт-се IClient

            Console.ReadKey();
        }
    }

    interface IClientAccount : IAccount, IClient
    {
        void GetIncome();
    }

    class VipClient : IClientAccount
    {
        public int CurrentSum { get; }
        public void GetIncome()
        {
            throw new NotImplementedException();
        }

        public void Put(int sum)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(int sum)
        {
            throw new NotImplementedException();
        }

        public string Name { get; set; }
    }

    interface IAccount
    {
        int CurrentSum { get; } //только для чтения
        void Put(int sum);
        void Withdraw(int sum);
    }

    interface IClient
    {
        string Name { get; set; }
    }

    class Client : IAccount, IClient
    {
        private int _sum;

        public Client(string name, int sum)
        {
            Name = name;
            _sum = sum;
        }

        public int CurrentSum
        {
            get { return _sum; }
        }

        public string Name { get; set; }

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
}