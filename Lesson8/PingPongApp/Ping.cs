using System;

namespace PingPongApp
{
    public class Ping
    {
        public event Action OnPing; 

        public void ReceivePong()
        {
            Console.WriteLine("Ping получил Pong");
            
            if (new Random().Next(0, 2) == 0) 
            {
                Console.WriteLine("Ping промахнулся! Победил Pong");
                return;
                
            }
            SendPing();
        }
        public void SendPing()
        {
            OnPing?.Invoke(); 
        }
    }
}