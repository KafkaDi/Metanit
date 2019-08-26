using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    delegate void AccountStateHendler(string messenge);
    class Account
    {
        int _sum;
        AccountStateHendler _del; //null

        public void RegisterHandler(AccountStateHendler del)
        {
            _del += del;
        }
        public void UnRegisterHandler(AccountStateHendler del)
        {
            _del -= del;
        }

        public Account(int sum)
        {
            _sum = sum;
        }

        public void Put(int sum)
        {
            _sum += sum;
            _del?.Invoke($"На счёт пришло {sum}");
        }
        public void Withdraw(int sum)
        {
            if (_sum >= sum)
            {
                _sum -= sum;
                _del?.Invoke($"Со счёта снято {sum}");
            }
            else
            {
                _del?.Invoke("На счёте недостаточно средств");
            }
        }
    }
}
