using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    delegate void AccountStateHendler(string messenge);
    class Account
    {
        int _sum;
        //AccountStateHendler _del; //null
        public event AccountStateHendler Added; //событие призшло называем третьей формой гл
        public event AccountStateHendler Adding;//если событие ещё не произошло для названия используем инговую ф-му гл
        public event AccountStateHendler Withdrawn;
        //public void RegisterHandler(AccountStateHendler del)
        //{
        //    _del += del;
        //}
        //public void UnRegisterHandler(AccountStateHendler del)
        //{
        //    _del -= del;
        //}

        public Account(int sum)
        {
            _sum = sum;
        }

        public void Put(int sum)
        {
            Adding?.Invoke($"На счёт добавляется {sum}"); //событие имеет те же параметры что и делегат который они представляют
            _sum += sum;
            Added?.Invoke($"На счёт пришло {sum}");
        }
        public void Withdraw(int sum)
        {
            if (_sum >= sum)
            {
                _sum -= sum;
                Withdrawn?.Invoke($"Со счёта снято {sum}");
            }
            else
            {
               Withdrawn?.Invoke("На счёте недостаточно средств");
            }
        }
    }
}
