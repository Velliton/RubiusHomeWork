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

            // Подписка на события
            ping.OnPing += pong.ReceivePing;
            pong.OnPong += ping.ReceivePong;

            // Игра начинается с "пинга"
            Console.WriteLine("Игра началась!");
            ping.SendPing();
        }
    }
}