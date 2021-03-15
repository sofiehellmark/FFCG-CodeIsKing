using System.Collections.Generic;

namespace StraightFlush.Program
{
    public interface IDeck
    {
        List<Card> DrawCards(int NumberOfCards);
        void ShuffledDeck();
    }
}