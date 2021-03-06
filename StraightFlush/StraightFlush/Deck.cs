using System;
using System.Collections.Generic;
using System.Linq;

namespace StraightFlush.Program
{

    public class Deck : IDeck
    {
        private List<Card> myDeck = new List<Card>(52);

        public Deck()
        {
            // string[] Suits = { "Heart", "Clubs", "Diamonds", "Spades" };
           // Suits suits = new Suits();
            IEnumerable<int> Values = Enumerable.Range(1, 13);

            foreach ( Suits Suit in Enum.GetValues(typeof(Suits))) 
            {
                foreach (int Value in Values)
                {
                    myDeck.Add(new Card(Value, Suit));
                }
            }
        }

        public void ShuffledDeck()
        {
            myDeck = myDeck.OrderBy(x => Guid.NewGuid()).ToList();
        }

        public List<Card> DrawCards(int NumberOfCards)
        {
            return myDeck.Take(NumberOfCards).ToList();
        }
    }
}
