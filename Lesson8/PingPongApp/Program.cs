using PingPongApp;
using System;

namespace PingPongApp
{
    class Program
    {
        static void Main()
        {
            Ping ping = new Ping();
            Pong pong = new Pong();

            
            ping.OnPing += pong.ReceivePing;
            pong.OnPong += ping.ReceivePong;

            
            Console.WriteLine("Игра началась!");
            ping.SendPing();
        }
    }
}