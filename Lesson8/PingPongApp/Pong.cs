using System;

namespace PingPongApp
{ 
    public class Pong
    {
        public event Action OnPong; // Событие для отправки "понга"

        public void ReceivePing()
        {
            Console.WriteLine("Pong получил Ping");
            // Генерация случайного числа: посылать событие или "промахнуться"
            if (new Random().Next(0, 2) == 0) // 0 - "промах", 1 - "успех"
            {
                Console.WriteLine("Pong промахнулся! Победил Ping");
                return;
            }
            SendPong();
           
        }
        public void SendPong()
        {
            OnPong?.Invoke(); // Безопасный вызов события
        }
    }
}