using System;
using System.Diagnostics.Metrics;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main()
        {
            Counter counter = new Counter();
            Handler1 handler1 = new Handler1();
            Handler2 handler2 = new Handler2();

            
            counter.OnThresholdReached += handler1.ReactToEvent;
            counter.OnThresholdReached += handler2.ReactToEvent;

            counter.StartCounting();
        }
    }
}