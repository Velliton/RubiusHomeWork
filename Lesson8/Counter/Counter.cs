using System;

namespace DelegatesAndEvents
{
    public delegate void CounterEventHandler();

    public class Counter
    {
        public event CounterEventHandler OnThresholdReached;

        public void StartCounting()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Счёт: {i}");
                if (i == 77)
                {
                    OnThresholdReached?.Invoke();
                }
            }
        }
    }
}