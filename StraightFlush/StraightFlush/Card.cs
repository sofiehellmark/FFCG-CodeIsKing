using System;
namespace StraightFlush.Program
{
    public class Card
    {
        public int Value { get;  }
        public Suits Suit { get; }

        public Card(int value, Suits suit)
        {
            Value = value;
            Suit = suit;
        }

        public override string ToString()
        {
            // case if over 10
            // return card as string
            return "";
        }
    }

}
