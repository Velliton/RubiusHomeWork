using System;

namespace PingPongApp
{ 
    public class Pong
    {
        public event Action OnPong; 

        public void ReceivePing()
        {
            Console.WriteLine("Pong получил Ping");
            
            if (new Random().Next(0, 2) == 0) 
            {
                Console.WriteLine("Pong промахнулся! Победил Ping");
                return;
            }
            SendPong();
           
        }
        public void SendPong()
        {
            OnPong?.Invoke(); 
        }
    }
}