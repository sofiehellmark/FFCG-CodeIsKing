using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StraightFlush.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var straightflush = new List<IRule>
            {
                new FlushRule(), new StraightRule()
            };

            var stopwatch = Stopwatch.StartNew();
            var simulateCardGame = new CardGameSimulator(straightflush);
            var tries = simulateCardGame.RunGame();
            var elapsedTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            var avg = tries / elapsedTotalSeconds;
            Console.Write($"\r Tries: {tries:N0} - Elapsed tid:  {stopwatch.Elapsed} - Tries per second: {avg:N0} \n");

          
        }
    }
}


// hand of 5 cards
// mix deck
// check straigh flush (being able to config rule)
// Try again
// Stop wathch
// Count tries

