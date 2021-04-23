using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StraightFlush.Program
{
    class Program
    {
        static void Main(string[] args)
        {

          
            var straightflush = new List<IRule>
            {
                new FlushRule(), new StraightRule(), new RoyalRule()
            };

            var stopwatch = Stopwatch.StartNew();
            var cardGameSimulator = new CardGameSimulator(straightflush);
            var tries = cardGameSimulator.RunGame();
            var elapsedTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            var avg = tries / elapsedTotalSeconds;
            Console.Write($"\r Tries: {tries:N0} - Elapsed tid:  {stopwatch.Elapsed} - Tries per second: {avg:N0} \n");


        }
    }
}

