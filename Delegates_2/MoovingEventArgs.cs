using System;

namespace Delegates_2
{
    public class MoovingEventArgs : EventArgs
    {
        public MoovingEventArgs(string message) //в конструктор мы передаём параметр при вызове события
        {
            Message = message;
        }

        public string Message { get; private set; } // в обработчике мы получаем эти параметры через соответствующие свойства
    }
}