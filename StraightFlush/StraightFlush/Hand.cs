using System;
using System.Collections.Generic;

namespace StraightFlush.Program
{
    public class Hand
    {
        public List<Card> myHand = new List<Card>(5);

        public Hand(List<Card> cards)
        {
            myHand = cards;
        }


        public List<Card> showHand()
        {
            return myHand;
        }

    }
}
