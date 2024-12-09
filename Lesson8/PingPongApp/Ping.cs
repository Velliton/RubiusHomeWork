using System;

namespace PingPongApp
{
    public class Ping
    {
        public event Action OnPing; // Событие для отправки "пинга"

        public void ReceivePong()
        {
            Console.WriteLine("Ping получил Pong");
            // Генерация случайного числа: посылать событие или "промахнуться"
            if (new Random().Next(0, 2) == 0) // 0 - "промах", 1 - "успех"
            {
                Console.WriteLine("Ping промахнулся! Победил Pong");
                return;
                
            }
            SendPing();
        }
        public void SendPing()
        {
            OnPing?.Invoke(); // Безопасный вызов события
        }
    }
}