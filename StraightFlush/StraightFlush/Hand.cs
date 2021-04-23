using System;
using System.Collections.Generic;

namespace StraightFlush.Program
{
    public class Hand
    {
        private List<Card> myHand = new List<Card>();

        public Hand(List<Card> cards)
        {
            myHand = cards;
        }


        public List<Card> ShowHand()
        {
            return myHand;
        }

        public void PrintHand()
        {
            foreach (Card cards in myHand)
            {
                Console.WriteLine($"{cards.Value} {cards.Suit}");
            }
        }

    }
}
